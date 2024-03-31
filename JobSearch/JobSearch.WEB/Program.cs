using System.Globalization;
using System.Text;
using JobSearch.BLL.DTO;
using JobSearch.BLL.Infrastructure.Authentication;
using JobSearch.BLL.Interfaces;
using JobSearch.WEB.Mapper;
using JobSearch.BLL.Providers;
using JobSearch.BLL.Services;
using JobSearch.DLL.Context;
using JobSearch.DLL.Interfaces;
using JobSearch.DLL.Repositories;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Serilog;

namespace JobSearch.WEB
{
    public class Program
	{
		public static void Main(string[] args)
		{
			var builder = WebApplication.CreateBuilder(args);
            var services = builder.Services;

            builder.Services.AddDistributedMemoryCache();
            builder.Services.AddSession(options =>
            {
                options.IdleTimeout = TimeSpan.FromMinutes(30);
                options.Cookie.IsEssential = true;
            });

            Log.Logger = new LoggerConfiguration().ReadFrom.Configuration(builder.Configuration).CreateLogger();
            builder.Host.UseSerilog();

            services.Configure<JwtOptions>(builder.Configuration.GetSection(nameof(JwtOptions)));

            services.AddControllersWithViews();
			services.AddDbContext<JobSearchContext>();
            services.AddAutoMapper(typeof(AutoMapperProfile));

			// DI
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IVacancyService, VacancyService>();
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IVacancyRepository, VacancyRepository>();
            services.AddScoped<IPasswordHasher, PasswordHasher>();
            services.AddScoped<IJwtProvider, JwtProvider>();

            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(JwtBearerDefaults.AuthenticationScheme, options =>
                {
                    options.SaveToken = true;
                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidIssuer = builder.Configuration["JwtOptions:ValidIssuer"],
                        ValidAudience = builder.Configuration["JwtOptions:ValidAudience"],
                        ValidateLifetime = true,
                        ValidateIssuerSigningKey = true,
                        ClockSkew = TimeSpan.FromSeconds(0),
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["JwtOptions:SecretKey"]))
                    };

                    options.Events = new JwtBearerEvents
                    {
                        OnMessageReceived = context =>
                        {
                            context.Token = context.Request.Cookies["tasty-cookies"];
                            return Task.CompletedTask;
                        },
                        OnAuthenticationFailed = async context =>
                        {
                            var accessToken = context.Request.Cookies["tasty-cookies"];
                            var refreshToken = context.Request.Cookies["very-tasty-cookies"];
                            if (!string.IsNullOrEmpty(accessToken) && !string.IsNullOrEmpty(refreshToken) && context.Exception.GetType() == typeof(SecurityTokenExpiredException))
                            {
                                var userService = context.HttpContext.RequestServices.GetRequiredService<IUserService>();
                                var newTokens = await userService.RefreshAccessToken(accessToken, refreshToken);
                                if (!string.IsNullOrEmpty(newTokens.AccessToken) && !string.IsNullOrEmpty(newTokens.RefreshToken))
                                {
                                    context.Response.Cookies.Append("tasty-cookies", newTokens.AccessToken);
                                    context.Response.Cookies.Append("very-tasty-cookies", newTokens.RefreshToken);
                                }
                            }
                        }
                    };
                });
            services.AddAuthorization();
            var app = builder.Build();

			if (!app.Environment.IsDevelopment())
			{
				app.UseExceptionHandler("/Home/Error");
				app.UseHsts();
			}

            app.UseSerilogRequestLogging();
			app.UseHttpsRedirection();
			app.UseStaticFiles();
            app.UseSession();
            app.UseRouting();
            app.Use(async (context, next) =>
            {
                if (context.Session != null)
                {
                    CultureInfo ci = new CultureInfo("uk");
                    if (context.Session.GetString("Culture") == null)
                    {
                        string langName = "uk";
                        ci = new CultureInfo(langName);
                        context.Session.Set("Culture", System.Text.Encoding.Default.GetBytes(ci.ToString()));
                    }
                    else
                    {
                        ci = new CultureInfo(context.Session.GetString("Culture"));
                    }

                    Thread.CurrentThread.CurrentCulture = ci;
                    Thread.CurrentThread.CurrentUICulture = ci;
                }

                await next();
            });

            app.UseAuthentication();
			app.UseAuthorization();

            app.MapControllerRoute(
                name: "Admin",
                pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}");

            app.MapControllerRoute(
				name: "default",
				pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
		}
	}
}

using JobSearch.BLL.DTO;
using JobSearch.BLL.Infrastructure.Authentication;
using JobSearch.BLL.Interfaces;
using JobSearch.WEB.Mapper;
using JobSearch.BLL.Providers;
using JobSearch.BLL.Services;
using JobSearch.DAL.Context;
using JobSearch.DAL.Interfaces;
using JobSearch.DAL.Repositories;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Serilog;
using JobSearch.WEB.Middlewares;
using JobSearch.WEB.Middlewares.ExtensionHelpers;

namespace JobSearch.WEB
{
    public class Program
	{
		public static async Task Main(string[] args)
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

            services.AddControllersWithViews().AddMvcOptions(opts =>
            {
                opts.Conventions.Add(new KebabCaseControllerModelConvention());
            });

            var connection = builder.Configuration.GetConnectionString("DefaultConnection");
            services.AddDbContext<JobSearchContext>
                (options => options.UseSqlServer(connection));

            services.AddAutoMapper(typeof(AutoMapperProfile));

            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IVacancyService, VacancyService>();
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IVacancyRepository, VacancyRepository>();
            services.AddScoped<IPasswordHasher, PasswordHasher>();
            services.AddScoped<IJwtProvider, JwtProvider>();

            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(JwtBearerDefaults.AuthenticationScheme, options =>
                {
                    options.ConfigureJwtBearerOptions(builder.Configuration);
                });
            services.AddAuthorization();

            services.Configure<RouteOptions>(options =>
            {
                options.AppendTrailingSlash = true;
                options.LowercaseUrls = true;
                options.LowercaseQueryStrings = true;
            });

            var app = builder.Build();
            await app.Services.MigrateDatabaseAsync();

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
            app.UseMiddleware<LocalizationMiddleware>();

            app.UseAuthentication();
			app.UseAuthorization();

            app.MapAreaControllerRoute(
                name: "admin",
                areaName:"Admin",
                pattern: "admin/{controller=Home}/{action=Index}/{id?}");

            app.MapDefaultControllerRoute();

            await app.RunAsync();
		}
	}
}

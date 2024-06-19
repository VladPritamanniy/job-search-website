using JobSearch.BLL.Interfaces;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace JobSearch.WEB.Middlewares.ExtensionHelpers
{
    public static class JwtBearerOptionsExtensionHelper
    {
        public static void ConfigureJwtBearerOptions(this JwtBearerOptions options, IConfiguration configuration)
        {
            options.SaveToken = true;
            options.TokenValidationParameters = new TokenValidationParameters
            {
                ValidIssuer = configuration["JwtOptions:ValidIssuer"],
                ValidAudience = configuration["JwtOptions:ValidAudience"],
                ValidateLifetime = true,
                ValidateIssuerSigningKey = true,
                ClockSkew = TimeSpan.FromSeconds(0),
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["JwtOptions:SecretKey"]))
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
        }
    }
}

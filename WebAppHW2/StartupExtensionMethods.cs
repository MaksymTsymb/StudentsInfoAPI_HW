using System.Text;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using BusinessLayer.Interfaces;
using BusinessLayer.Models;
using BusinessLayer.Services;
using DataAccessLayer.Repositories;
using DataAccessLayer.Interfaces;

namespace WebAppHW2
{
    public static class StartupExtensionMethods
    {
        public static void RegisterServices(this IServiceCollection services)
        {
            services.AddScoped<IStudentsInfoService, StudentsInfoService>();
            services.AddScoped<IStudentsInfoRepository, StudentsInfoRepositoryEFCore>();
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IAuthService, BusinessLayer.Services.AuthenticationService>();
            services.AddScoped<ISessionService, SessionService>();
            services.AddScoped<IHashService, HashService>();
            services.AddScoped<IMailExchangerService, MailExchangerService>();
            services.AddScoped<IMailService, MailService>();
            services.AddScoped<IMailRepository, MailRepository>();
        }

        public static void AddAuthentication(this IServiceCollection services, AppSettings appSettings)
        {
            var key = Encoding.ASCII.GetBytes(appSettings.Secret);
            services.AddAuthentication(auth =>
            {
                auth.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                auth.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(options =>
            {
                options.SaveToken = true;
                options.RequireHttpsMetadata = false;
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = false,
                    ValidateAudience = false,
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(key)
                };
            });
        }
    }
}

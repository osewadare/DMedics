using System;
using System.Text;
using DMedics.Domain.Entities;
using DMedics.Repository.Repository;
using DMedics.Services.Settings;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;

namespace DMedics.Infrastructure
{
    public static class Injectcion
    {
        public static IServiceCollection RegisterInfrastructureServices(
            this IServiceCollection service,
            IConfiguration configuration, string Issuer, string Audience, string Key)
        {
            service.AddDbContext<DataContext>();
            service.AddScoped(typeof(IBaseRepository<>), typeof(BaseRepository<>));

            service.AddIdentity<ApplicationUser, IdentityRole>(o =>
            {
                o.Stores.MaxLengthForKeys = 128;
                o.SignIn.RequireConfirmedAccount = false;
                o.User.RequireUniqueEmail = true;

                o.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(30);
                o.Lockout.MaxFailedAccessAttempts = 3;
                o.Lockout.AllowedForNewUsers = false;

                o.Password.RequireDigit = true;
                o.Password.RequiredLength = 6;
                o.Password.RequireNonAlphanumeric = true;
                o.Password.RequireUppercase = true;
                o.Password.RequireLowercase = false;
                o.Password.RequiredUniqueChars = 6;

            })
           .AddEntityFrameworkStores<DataContext>()
           .AddDefaultTokenProviders();

            service
                .AddAuthentication(o => o.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(o =>
                {
                    o.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuerSigningKey = true,
                        ValidateIssuer = true,
                        ValidateAudience = true,
                        ValidateLifetime = true,
                        ClockSkew = TimeSpan.Zero,
                        ValidIssuer = Issuer,
                        ValidAudience = Audience,
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Key))
                    };
                });

            service.Configure<JwtSecurityTokenSettings>(configuration.GetSection("JwtSecurityToken"));


            return service;
        }
    }
}

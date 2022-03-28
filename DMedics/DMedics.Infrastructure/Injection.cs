using System;
using DMedics.Domain.Entities;
using DMedics.Repository.Repository;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace DMedics.Infrastructure
{
    public static class Injectcion
    {
        public static IServiceCollection RegisterInfrastructureServices(
            this IServiceCollection service,
            IConfiguration configuration)
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

            return service;
        }
    }
}

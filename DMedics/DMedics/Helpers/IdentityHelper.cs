using DMedics.Core.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DMedics.API.Helpers
{
    public class IdentityHelper
    {
        public static void ConfigureService(IServiceCollection service)
        {
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

        }
    }
}

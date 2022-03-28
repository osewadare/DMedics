using System;
using DMedics.Repository.Repository;
using DMedics.Services.Interfaces;
using DMedics.Services.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace DMedics.Infrastructure
{
    public static class Injectcion
    {
        public static IServiceCollection RegisterApplicationServices(
            this IServiceCollection service,
            IConfiguration configuration)
        {
            service.AddScoped<IAppointmentService, AppointmentService>();

            service.AddScoped<IPaymentService, PaymentService>();

            service.AddScoped<IAuthenticationService, AuthenticationService>();

            return service;
        }
    }
}

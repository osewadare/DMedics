using DMedics.Services.Interfaces;
using Newtonsoft.Json;
using Stripe;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DMedics.Services.Services
{
    public class PaymentService : IPaymentService
    {

        public PaymentService()
        {

        }

        public string CreatePaymentIntent()
        {
            var paymentIntentService = new PaymentIntentService();
            var paymentIntent = paymentIntentService.Create(new PaymentIntentCreateOptions
            {
                Amount = 1,
                Currency = "$",
                AutomaticPaymentMethods = new PaymentIntentAutomaticPaymentMethodsOptions
                {
                    Enabled = true,
                },
            });
            return paymentIntent.ClientSecret;
        }

    }


}

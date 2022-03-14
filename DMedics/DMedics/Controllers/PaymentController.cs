using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DMedics.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Stripe;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace DMedics.API.Controllers
{
    public class PaymentController : Controller
    {
        private readonly IPaymentService _paymentService;

        public PaymentController(IPaymentService paymentService)
        {
            _paymentService = paymentService;
        }

        [Route("create-payment-intent")]
        [ApiController]
        public class PaymentIntentApiController : Controller
        {
            [HttpPost]
            public ActionResult Create(PaymentIntentCreateRequest request)
            {

                _paym
                return Json(new { clientSecret = paymentIntent.ClientSecret });
           }

           
    }
}
}



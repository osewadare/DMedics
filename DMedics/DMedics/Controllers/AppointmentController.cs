using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DMedics.Services.APIModels;
using DMedics.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace DMedics.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AppointmentController : Controller
    {

        private readonly IAppointmentService _appointmentService;

        public AppointmentController(IAppointmentService appointmentService)
        {
            _appointmentService = appointmentService;
        }
        
        [HttpGet]
        [Route("get-created-appointment-dates")]
        public IActionResult GetCreatedAppointmentDates([FromQuery]string clinicId)
        {
            var response = _appointmentService.GetCreatedAppointmentDates(clinicId);
            return Ok(response);
        }

        [HttpGet]
        [Route("get-clinics")]
        public IActionResult GetClinics()
        {
            var response = _appointmentService.GetClinics();
            return Ok(response);
        }

        [HttpGet]
        [Route("get-available-appointment-types")]
        public IActionResult GetAvailableAppointmentTypes()
        {
            var response = _appointmentService.GetAvailableAppointmentTypes();
            return Ok(response);
        }

        [HttpPost]
        [Route("create-appointment-booking-intent")]
        public IActionResult CreateAppointmentBookingIntent(AppointmentRequestModel requestModel)
        {
            var response = _appointmentService.CreateAppointmentBookingIntent(requestModel);
            return Ok(response);
        }


        [HttpGet]
        [Route("update-appointment-payment-status")]
        public IActionResult UpdateAppointmentPaymentStatus([FromQuery]string paymentSecret, [FromQuery] string status)
        {
            var response = _appointmentService.UpdateAppointmentPaymentStatus(paymentSecret, status);
            return Ok(response);
        }


        [HttpGet]
        [Route("get-appointment")]
        public IActionResult GetAppointment([FromQuery]string appointmentReference)
        {
            var response = _appointmentService.GetAppointment(appointmentReference);
            return Ok(response);
        }


        [HttpPost]
        [Route("create-appointment")]
        public IActionResult CreateAppointment(CreateAppointmentRequestModel requestModel)
        {
            var response = _appointmentService.CreateAppointment(requestModel);
            return Ok(response);
        }


        [HttpPost]
        [Route("update-appointment")]
        public IActionResult UpdateAppointment(CreateAppointmentRequestModel requestModel)
        {
            var response = _appointmentService.UpdateAppointment(requestModel);
            return Ok(response);
        }
    }
}

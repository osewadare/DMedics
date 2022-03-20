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
        [Route("GetCreatedAppointmentDates")]
        public IActionResult GetCreatedAppointmentDates(string clinicId)
        {
            var response = _appointmentService.GetCreatedAppointmentDates(clinicId);
            return Ok(response);

        }


        [HttpGet]
        [Route("GetAvailableAppointmentTypes")]
        public IActionResult GetAvailableAppointmentTypes()
        {
            var response = _appointmentService.GetAvailableAppointmentTypes();
            return Ok(response);
        }


        [HttpGet]
        [Route("BookAppointment")]
        public IActionResult CreateAppointmentBookingIntent(AppointmentRequestModel requestModel)
        {
            var response = _appointmentService.CreateAppointmentBookingIntent(requestModel);
            return Ok(response);
        }
    }
}

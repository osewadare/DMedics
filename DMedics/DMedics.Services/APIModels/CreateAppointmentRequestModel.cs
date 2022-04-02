using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using DMedics.Domain.Enums;
using static DMedics.Domain.Entities.ApplicationUser;

namespace DMedics.Services.APIModels
{
    public class CreateAppointmentRequestModel
    {

        public string AppointmentId { get; set; }

        [Required]
        public string ClinicId { get; set; }

        [Required]
        public string UserId { get; set; }

        [Required]
        public string AppointmentDateTime { get; set; }

    }
}

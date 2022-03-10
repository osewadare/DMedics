using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using static DMedics.Core.Entities.ApplicationUser;

namespace DMedics.Services.APIModels
{
    public class AppointmentRequestModel
    {
        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }

        [Required]
        public string EmailAddress { get; set; }

        [Required]
        public string DOB { get; set; }

        [Required]
        public string PhoneNumber { get; set; }

        [Required]
        public Gender Gender { get; set; }

        [Required]
        public string ClinicId { get; set; }

        [Required]
        public string AppointmentId { get; set; }

        [Required]
        public string AppointmentTypeId { get; set; }


    }
}

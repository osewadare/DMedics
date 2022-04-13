using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using DMedics.Domain.Enums;
using static DMedics.Domain.Entities.ApplicationUser;

namespace DMedics.Services.APIModels
{
    public class AppointmentRequestModel
    {

        //Customer Information
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
        public string Gender { get; set; }

        //[Required]
        public string ClinicId { get; set; }

        //[Required]
        public string AppointmentId { get; set; }

        [Required]
        public string AppointmentTypeId { get; set; }

        public string PostCode { get; set; }


    }
}

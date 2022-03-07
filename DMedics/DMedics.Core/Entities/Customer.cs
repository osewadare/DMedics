using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DMedics.Core.Entities
{
    public class Customer
    {
        [Required]
        [MaxLength(50)]
        public string FirstName { get; set; }

        [Required]
        [MaxLength(50)]
        public string LastName { get; set; }

        public DateTime DOB { get; set; }

        [Required]
        [MaxLength(50)]
        public string EmailAddress { get; set; }

        [Required]
        [MaxLength(15)]
        public string PhoneNumber { get; set; }

        [Required]
        [MaxLength(50)]
        public string PostCode { get; set; }

        [Required]
        [MaxLength(250)]
        public string ReferralSource { get; set; }

    }
}

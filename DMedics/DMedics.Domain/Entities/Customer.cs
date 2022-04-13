using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DMedics.Domain.Enums;

namespace DMedics.Domain.Entities
{
    public class Customer
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(50)]
        public string FirstName { get; set; }

        [Required]
        [MaxLength(50)]
        public string LastName { get; set; }

        public DateTime DOB { get; set; }

        public Gender Gender { get; set; }

        [Required]
        [MaxLength(50)]
        public string EmailAddress { get; set; }

        [Required]
        [MaxLength(15)]
        public string PhoneNumber { get; set; }

        [Required]
        [MaxLength(50)]
        public string PostCode { get; set; }

        [MaxLength(250)]
        public string ReferralSource { get; set; }

    }
}

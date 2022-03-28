using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DMedics.Domain.Entities
{
    public class Clinic
    {
        public int ClinicId { get; set; }
        [Required]
        [MaxLength(50)]
        public string ClinicName { get; set; }
        [Required]
        [MaxLength(50)]
        public string ClinicEmail { get; set; }
        [Required]
        [MaxLength(15)]
        public string ClinicPhoneNumber { get; set; }
        [Required]
        [MaxLength(10)]
        public string ClinicPostCode { get; set; }
        [Required]
        [MaxLength(250)]
        public string ClinicAddress { get; set; }
    }
}

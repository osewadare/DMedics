using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DMedics.Core.Entities
{
   public class AppointmentType
    {
        public int AppointmentTypeId { get; set; }
        [Required]
        [MaxLength(50)]
        public string TypeTitle { get; set; }
        [Required]
        [MaxLength(250)]
        public string TypeDescription { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DMedics.Core.Entities
{
    public class StatusTitle
    {
        public int AppointmentStatusId { get; set; }

        [Required]
        [MaxLength(50)]
        public string AppointmentStatusTitle
        {
            get; set;
        }
    }
}

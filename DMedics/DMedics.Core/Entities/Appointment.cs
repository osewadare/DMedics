using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DMedics.Core.Enums;

namespace DMedics.Core.Entities
{
   public class Appointment
    {
        public int AppointmentId { get; set; }

        public int CustomerId { get; set; }

        //Navigation Property
        public Customer Customer { get; set; }

        public int AppointmentTypeId { get; set; }

        //Navigation Property
        public AppointmentType AppointmentType { get; set; }

        public int UserId { get; set; }

        //Navigation Property
        public ApplicationUser ApplicationUser { get; set; }

        public DateTime AppointmentTime { get; set; }

        public int ClinicId { get; set; }

        //Navigation Property
        public Clinic Clinic { get; set; }
        
        public int AppointmentStatusId { get; set; }

        //Navigation Property
        public AppointmentStatus AppointmentStatus { get; set; }
    }
}

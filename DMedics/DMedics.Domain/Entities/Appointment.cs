using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DMedics.Domain.Enums;

namespace DMedics.Domain.Entities
{
   public class Appointment
    {
        public int AppointmentId { get; set; }

        //Navigation Property
        [ForeignKey(nameof(Customer))]
        public int? CustomerId { get; set; }
        public Customer Customer { get; set; }

        //Navigation Property
        [ForeignKey(nameof(AppointmentType))]
        public int? AppointmentTypeId { get; set; }
        public AppointmentType AppointmentType { get; set; }

        //Navigation Property
        [ForeignKey(nameof(ApplicationUser))]
        public string ApplicationUserId { get; set; }
        public ApplicationUser ApplicationUser { get; set; }

        public DateTime AppointmentTime { get; set; }

        //Navigation Property
        [ForeignKey(nameof(ClinicId))]
        public int? ClinicId { get; set; }
        public Clinic Clinic { get; set; }
        
        //Navigation Property
        public AppointmentStatus AppointmentStatus { get; set; }

        public string AppointmentReference { get; set; }

        public string PaymentSecret { get; set; }

    }
}

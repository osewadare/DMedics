using System;
using System.Collections.Generic;
using DMedics.Domain.Entities;
using DMedics.Domain.Enums;

namespace DMedics.Services.APIModels
{
    public class AppointmentsViewModel: BaseResponse
    {
        public List<AppointmentsModel> appointments { get; set; }

    }

    public class AppointmentsModel
    {
        public int AppointmentId { get; set; }

        public string CustomerName { get; set; }

        public string AppointmentType { get; set; }

        public string DoctorName { get; set; }

        public DateTime AppointmentTime { get; set; }

        public string ClinicName { get; set; }

        public string AppointmentStatus { get; set; }

        public string AppointmentReference { get; set; }

    }
}

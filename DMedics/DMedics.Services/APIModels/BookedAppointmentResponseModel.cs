using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DMedics.Services.APIModels
{
    public class BookedAppointmentResponseModel: BaseResponse
    {
        public string AppointmentReference { get; set; }

        public string FirstName { get; set; }

        public string AppointmentDateTime { get; set; }

        public string Clinic { get; set; }

    }
}

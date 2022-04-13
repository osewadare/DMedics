using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DMedics.Services.APIModels
{
    public class CreatedAppointmentResponseModel: BaseResponse
    {
        public List<CreatedAppointmentModel> createdAppointmentResponseModel { get; set; }
    }

    public class CreatedAppointmentModel
    {
        public string AppointmentId { get; set; }
        public DateTime AppointmentDateTime { get; set; }
    }
}

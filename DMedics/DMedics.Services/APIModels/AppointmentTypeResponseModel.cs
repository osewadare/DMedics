using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DMedics.Services.APIModels
{
    public class AppointmentTypeResponseModel: IBaseResponse
    {
        public List<AppointmentTypeModel> appointmentTypes { get; set; }
    }

    public class AppointmentTypeModel 
    {
        public int AppointmentTypeId { get; set; }

        public string TypeTitle { get; set; }

        public string TypeDescription { get; set; }
    }


}

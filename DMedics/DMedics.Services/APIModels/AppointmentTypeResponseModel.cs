using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DMedics.Services.APIModels
{
    public class AppointmentTypeResponseModel
    {

        public int AppointmentTypeId { get; set; }

        public string TypeTitle { get; set; }

        public string TypeDescription { get; set; }
    }
}

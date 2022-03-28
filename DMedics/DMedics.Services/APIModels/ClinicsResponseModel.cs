using System;
using System.Collections.Generic;

namespace DMedics.Services.APIModels
{

    public class ClinicsResponseModel : IBaseResponse
    {
        public List<ClinicsModel> clinicsResponse { get; set; }
    }

    public class ClinicsModel
    {
        public int ClinicId { get; set; }
       
        public string Clinic { get; set; }
    }
}

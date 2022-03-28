using System;
namespace DMedics.Services.APIModels
{
    public class IBaseResponse
    {
        public bool IsSuccessful { get; set; }
        public string Message { get; set; }
        public string StatusCode { get; set; }
    }
}

using System;
namespace DMedics.Services.APIModels
{
    public class BaseResponse
    {
        public bool IsSuccessful { get; set; }
        public string Message { get; set; }
        public string StatusCode { get; set; }
    }
}

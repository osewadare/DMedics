using System;
namespace DMedics.Services.APIModels
{
    public class TokenViewModel : BaseResponse
    {
        public TokenModel Data { get; set; }
    }

    public class TokenModel
    {
        public string Token { get; set; }
        public string Name { get; set; }
        public string ProfilePictureURL { get; set; }
        public string Message { get; set; }
        public string CustomerId { get; set; }

    }
}

using System;
namespace DMedics.Services.APIModels
{
    public class TokenViewModel : IBaseResponse
    {
        public TokenModel Data { get; set; }
    }

    public class TokenModel
    {
        public bool? HasVerifiedEmail { get; set; }
        public string Token { get; set; }
        public string Name { get; set; }
        public string ProfilePictureURL { get; set; }

    }
}

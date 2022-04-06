using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DMedics.Domain.Entities;
using DMedics.Services.APIModels;

namespace DMedics.Services.Interfaces
{
    public interface IAuthenticationService
    {
        Task<BaseResponse> SignUp(SignUpRequestModel signUpRequest);

        Task<BaseResponse> ResetPassword(ResetPasswordViewModel model);

        Task<BaseResponse> CreateToken(LoginViewModel loginModel);

        BaseResponse GetUsers();

    }
}

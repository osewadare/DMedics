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
        Task<IBaseResponse> SignUp(SignUpRequestModel signUpRequest);

        IBaseResponse ForgotPassword(ForgotPasswordViewModel model);

        IBaseResponse ResetPassword(ResetPasswordViewModel model);

        Task<TokenViewModel> Login(LoginRequestViewModel loginModel);

    }
}

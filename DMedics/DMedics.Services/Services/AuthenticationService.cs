using DMedics.Domain.Entities;
using DMedics.Services.APIModels;
using DMedics.Services.Constants;
using DMedics.Services.Interfaces;
using DMedics.Services.Settings;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DMedics.Services.Services
{
    public class AuthenticationService : IAuthenticationService
    {

        private readonly UserManager<ApplicationUser> _userManager;
        private readonly ILogger<AuthenticationService> _logger;
        private readonly JwtSecurityTokenSettings _jwt;

        public AuthenticationService
            (ILogger<AuthenticationService> logger,
            UserManager<ApplicationUser> userManager,
            IOptions<JwtSecurityTokenSettings> jwt)
        {
            _userManager = userManager;
            _logger = logger;
        }


        public IBaseResponse ForgotPassword(ForgotPasswordViewModel model)
        {
            throw new NotImplementedException();
        }

        public Task<TokenViewModel> Login(LoginRequestViewModel loginModel)
        {
            throw new NotImplementedException();
        }

        public IBaseResponse ResetPassword(ResetPasswordViewModel model)
        {
            throw new NotImplementedException();
        }

        public async Task<IBaseResponse> SignUp(SignUpRequestModel signUpRequest)
        {
            try
            {

                if (!signUpRequest.Email.EndsWith("@dmedics.com"))
                {
                    return new IBaseResponse
                    {
                        IsSuccessful = false,
                        Message = "You're not allowed to perform this operation",
                        StatusCode = StatusCodes.GeneralError
                    };
                }
                var user = new ApplicationUser
                {
                    UserName = signUpRequest.Email,
                    Email = signUpRequest.Email,
                    FirstName = signUpRequest.FirstName,
                    LastName = signUpRequest.LastName,
                    
                };


                var result = await _userManager.CreateAsync(user, signUpRequest.Password).ConfigureAwait(false);
                if (result.Succeeded)
                {
                    //await _userManager.AddToRoleAsync(user, role.ToString());
                    //var code = await _userManager.GenerateEmailConfirmationTokenAsync(user).ConfigureAwait(false);
                    // await _emailService.SendEmailConfirmationAsync(signUpRequest.Email, callbackUrl).ConfigureAwait(false);
                    return new IBaseResponse
                    {
                        IsSuccessful = true,
                        Message = ResponseMessages.SignUpSuccessful,
                        StatusCode = StatusCodes.Successful
                    };

                }
                return new IBaseResponse
                {
                    IsSuccessful = false,
                    Message = string.Join("\n", result.Errors.Select(x => x.Description).ToArray()),
                    StatusCode = StatusCodes.GeneralError
                };
            }
            catch (Exception ex)
            {
                _logger.LogInformation($"SignUp Exception: {ex}");
                return new IBaseResponse
                {
                    IsSuccessful = false,
                    Message = ResponseMessages.ExceptionMessage,
                    StatusCode = StatusCodes.GeneralError
                };
            }
        }


        public ApplicationUser User (String UserId)
        {
           throw new NotImplementedException();
        }


    }
}

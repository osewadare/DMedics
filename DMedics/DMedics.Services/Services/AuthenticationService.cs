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
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Net;
using System.Net.Sockets;
using Microsoft.IdentityModel.Tokens;

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
            _jwt = jwt.Value;
        }


        public BaseResponse ForgotPassword(ForgotPasswordViewModel model)
        {
            return new BaseResponse { };
        }

        public async Task<BaseResponse> CreateToken(LoginViewModel loginModel)
        {
            try
            {
                var user = await _userManager.FindByEmailAsync(loginModel.Email).ConfigureAwait(false);
                if (user == null)
                    return new BaseResponse
                    {
                        IsSuccessful = false,
                        StatusCode = StatusCodes.NoRecordFound,
                        Message = Messages.InvalidLogin
                    };

                var tokenModel = new TokenViewModel();
                if (await _userManager.CheckPasswordAsync(user, loginModel.Password).ConfigureAwait(false))
                {
                    JwtSecurityToken jwtSecurityToken = await CreateJwtToken(user).ConfigureAwait(false);
                    tokenModel.Data = new TokenModel
                    {
                        Token = new JwtSecurityTokenHandler().WriteToken(jwtSecurityToken),
                        CustomerId = user.Id,
                        Message = "success",
                        Name = user.FirstName
                    };
                    tokenModel.StatusCode = StatusCodes.Successful;
                    tokenModel.IsSuccessful = true;
                    return tokenModel;
                }
                return new BaseResponse
                {
                    IsSuccessful = false,
                    StatusCode = StatusCodes.NoRecordFound,
                    Message = Messages.InvalidLogin
                };
            }
            catch (Exception e)
            {
                _logger.LogInformation($"CreateToken Exception: {e}");
                return new BaseResponse
                {
                    IsSuccessful = false,
                    StatusCode = StatusCodes.FatalError,
                    Message = Messages.ExceptionMessage
                };
            }
        }

        private async Task<JwtSecurityToken> CreateJwtToken(ApplicationUser user)
        {
            var userClaims = await _userManager.GetClaimsAsync(user).ConfigureAwait(false);
            var roles = await _userManager.GetRolesAsync(user).ConfigureAwait(false);

            var roleClaims = new List<Claim>();

            for (int i = 0; i < roles.Count; i++)
            {
                roleClaims.Add(new Claim("roles", roles[i]));
            }
            string ipAddress = GetIpAddress();
            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.Sub, user.UserName),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim(JwtRegisteredClaimNames.Email, user.Email),
                new Claim("uid", user.Id),
                new Claim("ip", ipAddress)
            }
            .Union(userClaims)
            .Union(roleClaims);

            var symmetricSecurityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwt.Key));
            var signingCredentials = new SigningCredentials(symmetricSecurityKey, SecurityAlgorithms.HmacSha256);

            var jwtSecurityToken = new JwtSecurityToken(
                issuer: _jwt.Issuer,
                audience: _jwt.Audience,
                claims: claims,
                expires: DateTime.UtcNow.AddMinutes(_jwt.DurationInMinutes),
                signingCredentials: signingCredentials);
            return jwtSecurityToken;
        }

        public BaseResponse ResetPassword(ResetPasswordViewModel model)
        {
            throw new NotImplementedException();
        }

        public async Task<BaseResponse> SignUp(SignUpRequestModel signUpRequest)
        {
            try
            {

                if (!signUpRequest.Email.EndsWith("@dmedics.com"))
                {
                    return new BaseResponse
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
                    return new BaseResponse
                    {
                        IsSuccessful = true,
                        Message = ResponseMessages.SignUpSuccessful,
                        StatusCode = StatusCodes.Successful
                    };

                }
                return new BaseResponse
                {
                    IsSuccessful = false,
                    Message = string.Join("\n", result.Errors.Select(x => x.Description).ToArray()),
                    StatusCode = StatusCodes.GeneralError
                };
            }
            catch (Exception ex)
            {
                _logger.LogInformation($"SignUp Exception: {ex}");
                return new BaseResponse
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


        public string GetIpAddress()
        {
            var host = Dns.GetHostEntry(Dns.GetHostName());
            foreach (var ip in host.AddressList)
            {
                if (ip.AddressFamily == AddressFamily.InterNetwork)
                {
                    return ip.ToString();
                }
            }
            return string.Empty;
        }

        public BaseResponse GetUsers()
        {
            try
            {
                var users = _userManager.Users.ToList();
                var usersViewModel = new UsersViewModel
                {
                    Users = users?.Select(x => new UsersModel
                    {
                        UserId = x.Id,
                        Name = $"{x.FirstName} {x.LastName}"
                    }).ToList(),
                    StatusCode = StatusCodes.Successful,
                    IsSuccessful = true,
                    Message = "success"
               };

               return usersViewModel;
            }
            catch (Exception e)
            {
                _logger.LogInformation($"GetUsers Exception: {e}");
                return new BaseResponse
                {
                    IsSuccessful = false,
                    StatusCode = StatusCodes.FatalError,
                    Message = Messages.ExceptionMessage
                };
            }
        }
    }

  
}

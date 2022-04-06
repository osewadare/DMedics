using System;
using System.Linq;
using System.Threading.Tasks;
using DMedics.Domain.Entities;
using DMedics.Services.APIModels;
using DMedics.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace DMedics.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthenticationController : Controller
    {
        private readonly IAuthenticationService _authService;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly UserManager<ApplicationUser> _userManager;


        public AuthenticationController(IAuthenticationService authService,
            SignInManager<ApplicationUser> signInManager,
            UserManager<ApplicationUser> userManager)
        {
            _authService = authService;
            _signInManager = signInManager;
            _userManager = userManager;
        }

        [AllowAnonymous]
        [HttpPost("signup")]
        public async Task<IActionResult> SignUp([FromBody] SignUpRequestModel model)
        {
            var response = await _authService.SignUp(model);
            return Ok(response);
        }


        [HttpPost]
        [Route("login")]
        public async Task<IActionResult> CreateToken([FromBody] LoginViewModel model)
        {
            var response = await _authService.CreateToken(model);
            return Ok(response);

        }


        [HttpGet]
        [Route("get-users")]
        public IActionResult GetUsers()
        {
            var response = _authService.GetUsers();
            return Ok(response);

        }

        [HttpPost]
        [Route("change-password")]
        public IActionResult ChangePassword(ResetPasswordViewModel model)
        {
            var userId = int.Parse(this.User.Claims.First(i => i.Type == "UserId").Value);
            var response = _authService.ResetPassword(model);
            return Ok(response);

        }



    }
}

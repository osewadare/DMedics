using System;
using System.ComponentModel.DataAnnotations;

namespace DMedics.Services.APIModels
{
    public class ResetPasswordViewModel
    {
        [Required]
        public string UserId { get; set; }

        public string Password { get; set; }

    }
}

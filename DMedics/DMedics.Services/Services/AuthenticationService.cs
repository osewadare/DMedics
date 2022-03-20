using DMedics.Core.Entities;
using DMedics.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace DMedics.Services.Services
{
    public class AuthenticationService : IAuthenticationService
    {
        public ApplicationUser User (String UserId)

        {
           throw new NotImplementedException();
        }

        ApplicationUser IAuthenticationService.GetPassword()
        {
            throw new NotImplementedException();
        }

        ApplicationUser IAuthenticationService.Login()
        {
            throw new NotImplementedException();
        }

        ApplicationUser IAuthenticationService.Logout()
        {
            throw new NotImplementedException();
        }
    }
}

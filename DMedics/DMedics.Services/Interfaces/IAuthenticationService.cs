using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DMedics.Core.Entities;

namespace DMedics.Services.Interfaces
{
    public interface IAuthenticationService
    {
        //Login
        ApplicationUser User (string UserId);
        ApplicationUser Login();
        //Logout
        ApplicationUser Logout();

        //Forgot password
        ApplicationUser GetPassword();
    }
}

using System;
using System.Collections.Generic;

namespace DMedics.Services.APIModels
{
    public class UsersViewModel : BaseResponse
    {
        public List<UsersModel> Users { get; set; }
    }

    public class UsersModel
    {
        public string UserId { get; set; }
        public string Name { get; set; }

    }
}

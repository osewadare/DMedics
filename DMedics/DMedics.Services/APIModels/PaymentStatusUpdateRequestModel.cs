using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using DMedics.Domain.Enums;
using static DMedics.Domain.Entities.ApplicationUser;

namespace DMedics.Services.APIModels
{
    public class PaymentStatusUpdateRequestModel
    {

        [Required]
        public string PaymentSecret { get; set; }

        [Required]
        public string Status { get; set; }

    }
}

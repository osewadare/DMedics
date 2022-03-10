using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DMedics.Core.Entities
{
    public class ApplicationUser : IdentityUser
    {
        private int userId;

        public ApplicationUser(int userId)
        {
            this.userId = userId;
        }

        [MaxLength(50)]
        [Required]
        public string FirstName { get; set; }

        [MaxLength(50)]
        [Required]
        public string LastName { get; set; }

        [Required]
        public DateTime DoB { get; set; }

        public enum Gender { }

        [MaxLength(50)]
        [Required]
        public string Country { get; set; }

        [MaxLength(50)]
        [Required]
        public string Address1 { get; set; }

        [MaxLength]
        public string Address2 { get; set; }

        [MaxLength(50)]
        [Required]
        public string City { get; set; }

        [MaxLength(15)]
        [Required]
        public string PostCode { get; set; }
    }
}

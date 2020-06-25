using System;
using System.ComponentModel.DataAnnotations;

namespace myPOS.Web.Models
{

    public class UserViewModel
    {
        public string Id { get; set; }

        [Required]
        public string UserName { get; set; }

        [EmailAddress]
        [Display(Name = "Email")]
        public string Email { get; set; }

        public DateTimeOffset? LockoutEnd { get; set; }

        public double Balance { get; set; }
    }


}

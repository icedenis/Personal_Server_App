using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Personal_Server_App.Models
{
    public class Register_Personal
    {
        [Required]
        [Display(Name = "Email Adress")]
        public string Username { get; set; }
        [Required]
        [DataType(DataType.Password)]
        [StringLength(15, ErrorMessage = "Max 15 char", MinimumLength = 8)]
        public string Password { get; set; }
        [Required]
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "Not the same password")]
        public string ConfirmPass { get; set; }

        public string role { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Personal_Server_App.Models
{
    public class ModelLogin
    {
        [Required]
        [Display(Name ="Username ")]
        public string Username { get; set; }
    
        [Display(Name = "Email Adress")]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [StringLength(15, ErrorMessage = "Max 15 char", MinimumLength = 8)]
        public string Password { get; set; }
 
    }
}

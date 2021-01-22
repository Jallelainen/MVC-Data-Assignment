using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MVC_Data_Assignment.Models.ViewModels
{
    public class SignUpViewModel
    {
        [Required]
        [Display(Name = "User Name")]
        [StringLength(15, MinimumLength = 4)]
        public string UserName { get; set; }

        [Required]
        [StringLength(30, MinimumLength = 6, ErrorMessage = "Password must contain atleast 1 upper and lower case letter as well as 1 digit")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required]
        [Display(Name = "Password Verification")]
        [Compare("Password")]
        [DataType(DataType.Password)]
        public string ControlPassword { get; set; }

        [Required]
        [DataType(DataType.Date)]
        public DateTime BirthDate { get; set; }

        [Required]
        public string FirstName { get; set; }
        
        [Required]
        public string LastName { get; set; }
        public string NoticeMessage { get; set; }
    }
}

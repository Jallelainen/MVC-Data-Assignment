using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MVC_Data_Assignment.Models.ViewModels
{
    public class LoginViewModel
    {
        [Required]
        [Display(Name = "User Name")]
        [StringLength(15, MinimumLength = 4)]
        public string UserName { get; set; }

        [Required]
        [StringLength(30, MinimumLength = 6)]
        public string Password { get; set; }
        
        public string NoticeMessage { get; set; }
    }
}

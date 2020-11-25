using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MVC_Data_Assignment.Models
{
    public class CreatePersonViewModel
    {
        [Required]
        public string Name { get; set; }

        [Display(Name = "Phone Number")]
        [Required]
        [StringLength(13, MinimumLength = 10)]
        public string PhoneNum { get; set; }

        [Required]
        public string City { get; set; }
    }
}

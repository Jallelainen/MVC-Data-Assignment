using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MVC_Data_Assignment.Models.ViewModels
{
    public class EditPersonViewModel
    {
        public int Id { get; set; }
        
        [Required]
        public string Name { get; set; }

        [Required]
        [Display(Name = "Phone Number")]
        [RegularExpression("^[0-9]{1,13}$", ErrorMessage = "Must only use numbers.")]
        public string PhoneNum { get; set; }

        [Required]
        public City City { get; set; }
    }
}

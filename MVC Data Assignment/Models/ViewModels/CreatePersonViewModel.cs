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

        [RegularExpression("^[0-9]{1,13}$", ErrorMessage = "Must only use numbers.")]
        public string PhoneNum { get; set; }

        public int LanguageId { get; set; }

        public PersonLanguage PersonLanguage { get; set;  }

        public City City { get; set; }

        public List<City>  cities { get; set; }

    }
}

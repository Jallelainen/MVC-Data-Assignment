using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MVC_Data_Assignment.Models.ViewModels
{
    public class CreateCountryViewModel
    {
        [Required]
        public string Name { get; set; }

        public List<City> CitiesList { get; set; }
        public List<Person> PersonList { get; set; }
    }
}

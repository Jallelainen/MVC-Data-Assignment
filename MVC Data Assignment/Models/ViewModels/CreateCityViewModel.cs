using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MVC_Data_Assignment.Models.ViewModels
{
    public class CreateCityViewModel
    {
        public int CityId { get; set; }

        [Required]
        public string Name { get; set; }
        public string Search { get; set; }
        public Country Country { get; set; }
        public List<City> cities { get; set; }
        public List<Country> CountryList { get; set; }
        public List<Person> CityPeopleList { get; set; }
    }
}

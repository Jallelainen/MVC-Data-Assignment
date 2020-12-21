using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MVC_Data_Assignment.Models
{
    public class Country
    {
        [Key]
        public string Name { get; set; }

        public List<City> CitiesList { get; set; }

        public List<Person> CountryPeopleList { get; set; }


        public Country (string name, List<City> cities, List<Person> countryPeople)
        {
            Name = name;
            CitiesList = cities;
            CountryPeopleList = countryPeople;
        }
    }
}

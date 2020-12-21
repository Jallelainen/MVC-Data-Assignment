using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVC_Data_Assignment.Models
{
    public class Country
    {
        public string Name { get; set; }

        public List<City> CitiesList { get; set; }

        public List<Person> CountryPeopleList { get; set; }

    }
}

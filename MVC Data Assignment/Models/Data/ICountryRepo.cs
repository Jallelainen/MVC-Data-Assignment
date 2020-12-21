using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVC_Data_Assignment.Models.Data
{
    interface ICountryRepo
    {
        Country Create(string name, List<City> cities, List<Person> countryPeople);
        Country Read(string name);
        Country Update(Country country);
        bool Delete(Country country);
    }
}

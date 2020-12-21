using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVC_Data_Assignment.Models.Data
{
    public class DBCountryRepo : ICountryRepo
    {
        public Country Create(string name, List<City> cities, List<Person> countryPeople)
        {
            throw new NotImplementedException();
        }

        public bool Delete(Country country)
        {
            throw new NotImplementedException();
        }

        public Country Read(string name)
        {
            throw new NotImplementedException();
        }

        public Country Update(Country country)
        {
            throw new NotImplementedException();
        }
    }
}

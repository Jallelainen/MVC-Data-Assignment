using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVC_Data_Assignment.Models.Data
{
    public class DBCityRepo : ICityRepo
    {
        public City Create(string name, Country country, List<Person> cityPeople)
        {
            throw new NotImplementedException();
        }

        public bool Delete(City city)
        {
            throw new NotImplementedException();
        }

        public City Read(int id, City city)
        {
            throw new NotImplementedException();
        }

        public City Update(City city)
        {
            throw new NotImplementedException();
        }
    }
}

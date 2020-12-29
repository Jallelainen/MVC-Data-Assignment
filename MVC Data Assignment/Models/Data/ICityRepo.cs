using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVC_Data_Assignment.Models.Data
{
    public interface ICityRepo
    {
        City Create(string name, Country country, List<Person> cityPeople);
        City Read(int id);
        List<City> Read();
        City Update(City city);
        bool Delete(City city);
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVC_Data_Assignment.Models.Data
{
    public interface IPeopleRepo
    {
        Person Create(string name, string phoneNum, string city);
        List<Person> Read();
        Person Read(int id);
        Person Update(Person people);
        bool Delete(Person people);
    }
}

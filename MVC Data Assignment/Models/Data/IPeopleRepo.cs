using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVC_Data_Assignment.Models.Data
{
    public interface IPeopleRepo
    {
        People Create(string name, string phoneNum, string city);
        List<People> Read();
        People Read(int id);
        People Update(People people);
        bool Delete(People people);
    }
}

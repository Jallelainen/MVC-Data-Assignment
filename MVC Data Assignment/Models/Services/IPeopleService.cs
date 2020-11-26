using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVC_Data_Assignment.Models.Services
{
    public interface IPeopleService
    {
        Person Add(CreatePersonViewModel createPersonViewModel);
        List<Person> All();
        Person FindBy(int id);
        Person Edit(int id, CreatePersonViewModel people);
        bool Remove(int id);
        List<Person> Search(string search);
    }
}

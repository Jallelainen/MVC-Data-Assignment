using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVC_Data_Assignment.Models.Services
{
    public interface IPeopleService
    {
        People Add(CreatePersonViewModel createPersonViewModel);
        List<People> All();
        People FindBy(int id);
        People Edit(int id, CreatePersonViewModel people);
        bool Remove(int id);
    }
}

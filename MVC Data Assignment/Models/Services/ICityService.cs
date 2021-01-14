using MVC_Data_Assignment.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVC_Data_Assignment.Models.Services
{
    public interface ICityService
    {
        City Add(CreateCityViewModel newCity);
        List<City> All();
        City FindBy(int id);
        City Edit(City city);
        bool Remove(int id);
        List<City> Search(string search);
    }
}

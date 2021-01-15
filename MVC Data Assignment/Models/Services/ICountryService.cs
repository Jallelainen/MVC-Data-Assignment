using MVC_Data_Assignment.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVC_Data_Assignment.Models.Services
{
    public interface ICountryService
    {
        Country Add(CreateCountryViewModel createCountryViewModel);
        List<Country> All();
        Country FindBy(int id);
        Country Edit(Country country);
        bool Remove(int id);
        List<Country> Search(string search);


    }
}

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
        Country FindBy(string name);
        Country Edit(string name, CreateCountryViewModel country);
        bool Remove(string name);
        List<Country> Search(string search);


    }
}

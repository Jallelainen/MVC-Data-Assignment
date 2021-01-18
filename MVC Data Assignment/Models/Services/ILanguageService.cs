using MVC_Data_Assignment.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVC_Data_Assignment.Models.Services
{
    public interface ILanguageService
    {
        Language Add(LanguageViewModel languageViewModel);
        List<Language> All();
        Language FindBy(int id);
        Language Edit(Language language);
        bool Remove(int id);
        List<Language> Search(string search);
    }
}

using MVC_Data_Assignment.Models.Data;
using MVC_Data_Assignment.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVC_Data_Assignment.Models.Services
{
    public class LanguageService : ILanguageService
    {
        ILanguageRepo _languageRepo;

        public LanguageService(ILanguageRepo languageRepo)
        {
            _languageRepo = languageRepo;
        }

        public Language Add(LanguageViewModel languageViewModel)
        {
            if (languageViewModel.Country != null)
            {
                Language language = new Language(languageViewModel.Name, languageViewModel.Country);
                if (_languageRepo.Create(language) != null)
                {
                    return language;
                }
                else
                {
                    return null;
                }
            }
            else
            {
                Language language = new Language(languageViewModel.Name);
                if (_languageRepo.Create(language) != null)
                {
                    return language;
                }
                else
                {
                    return null;
                }
            }
        }

        public List<Language> All()
        {
            return _languageRepo.Read();
        }

        public Language Edit(Language language)
        {
            language = _languageRepo.Read(language.Id);
            if (language != null)
            {
                return _languageRepo.Update(language);
            }
            else
            {
                return null;
            }
        }

        public Language FindBy(int id)
        {
            return _languageRepo.Read(id);
        }

        public bool Remove(int id)
        {
            Language language = _languageRepo.Read(id);
            if (language != null)
            {
                return _languageRepo.Delete(language);
            }
            else
            {
                return false;
            }
        }

        public List<Language> Search(string search)
        {
            List<Language> findings = new List<Language>();
            foreach (var item in _languageRepo.Read())
            {
                if (item.Name.ToUpper().Contains(search.ToUpper()))
                {
                    findings.Add(item);
                }
            }

            return findings;
        }
    }
}

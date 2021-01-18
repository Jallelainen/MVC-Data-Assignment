using Microsoft.EntityFrameworkCore;
using MVC_Data_Assignment.Models.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVC_Data_Assignment.Models.Data
{
    public class DBLanguageRepo : ILanguageRepo
    {
        private readonly PeopleDbContext _peopleDbContext;

        public DBLanguageRepo(PeopleDbContext peopleDbContext)
        {
            _peopleDbContext = peopleDbContext;
        }

        public Language Create(Language language)
        {
            _peopleDbContext.Languages.Add(language);

            if (_peopleDbContext.SaveChanges() != 0)
            {
                return language;
            }
            else
            {
                return null;
            }
        }

        public bool Delete(Language language)
        {
            if (language != null)
            {
                _peopleDbContext.Remove(language);

                if (_peopleDbContext.SaveChanges() != 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }

        public List<Language> Read()
        {
            return _peopleDbContext.Languages.ToList();
        }

        public Language Read(int id)
        {
            return _peopleDbContext.Languages.Include(l => l.Speakers).ThenInclude(l => l.Person).SingleOrDefault(l => l.Id == id);
        }

        public Language Update(Language language)
        {
            _peopleDbContext.Languages.Update(language);
            if (_peopleDbContext.SaveChanges() != 0)
            {
                return language;
            }
            else
            {
                return null;
            }
        }
    }
}

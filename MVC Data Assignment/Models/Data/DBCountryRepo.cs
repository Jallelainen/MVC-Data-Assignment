using Microsoft.EntityFrameworkCore;
using MVC_Data_Assignment.Models.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVC_Data_Assignment.Models.Data
{
    public class DBCountryRepo : ICountryRepo
    {
        private readonly IdentityPersonDbContext _peopleDbContext;

        public DBCountryRepo(IdentityPersonDbContext peopleDbContext)
        {
            _peopleDbContext = peopleDbContext;
        }

        public Country Create(string name)
        {
            Country country = new Country(name);
            
            _peopleDbContext.CountryList.Add(country);

            if (_peopleDbContext.SaveChanges() != 0)
            {
                return country;
            }
            else
            {
                return null;
            }
        }

        public bool Delete(Country country)
        {
            if (country != null)
            {
                _peopleDbContext.CountryList.Remove(country);

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

        public Country Read(int id)
        {
            return _peopleDbContext.CountryList.Include(c => c.CitiesList).SingleOrDefault(countryList => countryList.ID == id);
        }

        public List<Country> Read()
        {
            return _peopleDbContext.CountryList.ToList();
        }

        public Country Update(Country country)
        {
            Country originalCountry = Read(country.ID);

            if (originalCountry == null)
            {
                return null;
            }

            originalCountry.Name = country.Name;
            originalCountry.CitiesList = country.CitiesList;

            _peopleDbContext.CountryList.Update(originalCountry);

            if (_peopleDbContext.SaveChanges() != 0)
            {
                return originalCountry;
            }
            else
            {
                return null;
            }
        }
    }
}

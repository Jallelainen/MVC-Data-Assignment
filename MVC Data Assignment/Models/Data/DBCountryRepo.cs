using MVC_Data_Assignment.Models.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVC_Data_Assignment.Models.Data
{
    public class DBCountryRepo : ICountryRepo
    {
        private readonly PeopleDbContext _peopleDbContext;

        public DBCountryRepo(PeopleDbContext peopleDbContext)
        {
            _peopleDbContext = peopleDbContext;
        }

        public Country Create(string name, List<City> cities)
        {
            Country country = new Country(name, cities);
            
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

        public Country Read(string name)
        {
            return _peopleDbContext.CountryList.SingleOrDefault(countryList => countryList.Name == name);
        }

        public List<Country> Read()
        {
            return _peopleDbContext.CountryList.ToList();
        }

        public Country Update(Country country)
        {
            Country originalCountry = Read(country.Name);

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

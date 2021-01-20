using Microsoft.EntityFrameworkCore;
using MVC_Data_Assignment.Models.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVC_Data_Assignment.Models.Data
{
    public class DBCityRepo : ICityRepo
    {
        private readonly IdentityPersonDbContext _peopleDbContext;

        public DBCityRepo(IdentityPersonDbContext peopleDbContext)
        {
            _peopleDbContext = peopleDbContext;
        }

        public City Create(string name, Country country, List<Person> cityPeople)
        {
            City city = new City(name, country, cityPeople);

            _peopleDbContext.CityList.Add(city);

            if (_peopleDbContext.SaveChanges() != 0)
            {
                return city;
            }
            else
            {
                return null;
            }
        }

        public bool Delete(City city)
        {
            if(city != null)
            {
                _peopleDbContext.CityList.Remove(city);

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

        public City Read(int id)
        {
            return _peopleDbContext.CityList.Include(c => c.CityPeopleList).Include(c => c.Country).SingleOrDefault(c => c.Id == id);
        }

        public List<City> Read()
        {
            return _peopleDbContext.CityList.ToList();
        }

        public City Update(City city)
        {
            City orginalCity = Read(city.Id);

            if (orginalCity == null)
            {
                return null;
            }

            orginalCity.Name = city.Name;
            orginalCity.Country = city.Country;
            orginalCity.CityPeopleList = city.CityPeopleList;

            _peopleDbContext.CityList.Update(orginalCity);

            if (_peopleDbContext.SaveChanges() != 0)
            {
                return orginalCity;
            }
            else
            {
                return null;
            }
        }
    }
}

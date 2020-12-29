using MVC_Data_Assignment.Models.Data;
using MVC_Data_Assignment.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVC_Data_Assignment.Models.Services
{
    public class CityService : ICityService
    {
        ICityRepo _cityRepo;

        public CityService(ICityRepo cityRepo)
        {
            _cityRepo = cityRepo;
        }

        public City Add(CreateCityViewModel newCity)
        {
            return _cityRepo.Create(newCity.Name, newCity.Country, newCity.CityPeopleList);
        }

        public List<City> All()
        {
            return _cityRepo.Read();
        }

        public City Edit(int id, CreateCityViewModel editCityViewModel)
        {
            City editedCity = new City(id, editCityViewModel.Name, editCityViewModel.Country, editCityViewModel.CityPeopleList);
            return _cityRepo.Update(editedCity);
        }

        public City FindBy(int id)
        {
            return _cityRepo.Read(id);
        }

        public bool Remove(int id)
        {
            City city = _cityRepo.Read(id);

            if (city == null)
            {
                return false;
            }
            else
            {
                return _cityRepo.Delete(city);
            }
        }

        public List<City> Search(string search)
        {
            List<City> filteredList = new List<City>();

            foreach (var item in All())
            {
                if (item.Name.ToUpper().Contains(search.ToUpper()) || item.Country.ToString().ToUpper().Contains(search.ToUpper()))
                {
                    filteredList.Add(item);
                }
            }

            return filteredList;
        }
    }
}

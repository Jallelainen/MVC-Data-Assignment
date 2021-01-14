﻿using MVC_Data_Assignment.Models.Data;
using MVC_Data_Assignment.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVC_Data_Assignment.Models.Services
{
    public class CountryService : ICountryService
    {
        ICountryRepo _countryRepo;

        public CountryService(ICountryRepo countryRepo)
        {
            _countryRepo = countryRepo;
        }

        public Country Add(CreateCountryViewModel createCountryViewModel)
        {
            return _countryRepo.Create(createCountryViewModel.Name);
        }

        public List<Country> All()
        {
            return _countryRepo.Read();
        }

        public Country Edit(string name, CreateCountryViewModel country)
        {
            Country editedCountry = new Country(name);
            return _countryRepo.Update(editedCountry);
        }

        public Country FindBy(int id)
        {
            return _countryRepo.Read(id);
        }

        public bool Remove(int id)
        {
            Country country = _countryRepo.Read(id);

            if (country == null)
            {
                return false;
            }
            else
            {
                return _countryRepo.Delete(country);
            }
        }

        public List<Country> Search(string search)
        {
            List<Country> filteredList = new List<Country>();

            foreach (var item in All())
            {
                if (item.Name.ToUpper().Contains(search.ToUpper()))
                {
                    filteredList.Add(item);
                }
            }

            return filteredList;
        }
    }
}
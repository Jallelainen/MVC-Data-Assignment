using Microsoft.AspNetCore.Mvc;
using MVC_Data_Assignment.Models;
using MVC_Data_Assignment.Models.Services;
using MVC_Data_Assignment.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVC_Data_Assignment.Controllers
{
    public class CountryController : Controller
    {
        private ICountryService _countryService;

        public CountryController(ICountryService countryService)
        {
            _countryService = countryService;
        }

        public IActionResult Index()
        {
            CreateCountryViewModel createCountryView = new CreateCountryViewModel();
            createCountryView.CountryList = _countryService.All();

            return View(createCountryView);
        }

        public IActionResult Details(int id)
        {
            Country country = new Country();
            country = _countryService.FindBy(id);

            return View(country);
        }

        [HttpGet]
        public IActionResult Create()
        {
            CreateCountryViewModel createCountryViewModel = new CreateCountryViewModel();

            return View(createCountryViewModel);
        }

        [HttpPost]
        public IActionResult Create(CreateCountryViewModel newCountry)
        {
            if (ModelState.IsValid)
            {
                Country country = _countryService.Add(newCountry);
                return RedirectToAction(nameof(Index));
            }
            else
            {
                Response.StatusCode = 418;
                return View(newCountry);
            }

        }

        public IActionResult Find(int id)
        {
            Country country = _countryService.FindBy(id);
            return View(country);
        }

        public IActionResult Update(CreateCountryViewModel editCountry)
        {
            
            if (ModelState.IsValid)
            {
                Country country = _countryService.FindBy(editCountry.Id);
                country.Name = editCountry.Name;
                _countryService.Edit(country);

                return RedirectToAction("Index");
            }
            else
            {
                Response.StatusCode = 400;
                return View();
            }
        }

        public IActionResult Delete(int id)
        {
            Country country = _countryService.FindBy(id);
            country.CitiesList.Clear();
            _countryService.Edit(country);

            if (_countryService.Remove(id))
            {
                return RedirectToAction("Index");
            }
            else
            {
                Response.StatusCode = 400;
                return View();
            }
        }
    }
}

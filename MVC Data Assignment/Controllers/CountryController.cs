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
            Country country = _countryService.FindBy(id);
            if (country != null)
            {
                return View(country);
            }
            else
            {
                return NotFound();
            }
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
                if (country != null)
                {
                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    return NotFound();
                }
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
            if (country != null)
            {
                return View(country);
            }
            else
            {
                return NotFound();
            }
        }

        public IActionResult Edit(int id)
        {
            Country country = _countryService.FindBy(id);
            if (country != null)
            {
                return View();
            }
            else
            {
                return NotFound();
            }
        }

        [HttpPost]
        public IActionResult Update(CreateCountryViewModel editCountry)
        {

            if (ModelState.IsValid)
            {
                Country country = _countryService.FindBy(editCountry.Id);
                if (country != null)
                {
                    country.Name = editCountry.Name;
                    _countryService.Edit(country);

                    return RedirectToAction("Index");
                }
                else
                {
                    return NotFound();
                }
            }
            else
            {

                return NotFound();
            }
        }

        public IActionResult Delete(int id)
        {
            Country country = _countryService.FindBy(id);
            if (country != null)
            {
                country.CitiesList.Clear();
                _countryService.Edit(country);

                if (_countryService.Remove(id))
                {
                    return RedirectToAction("Index");
                }
                else
                {
                    return NotFound();
                }
            }
            else
            {
                return NotFound();
            }
        }
    }
}

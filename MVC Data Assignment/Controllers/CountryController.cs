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
            return View(_countryService.All());
        }

        public IActionResult Details(int id)
        {
            Country country = new Country();
            country = _countryService.FindBy(id); 

            return PartialView("_CountryDetailPartial", country);
        }

        [HttpGet]
        public IActionResult Create()
        {
            CreateCountryViewModel createCountryViewModel = new CreateCountryViewModel();

            return PartialView("_CreateCountryPartial", createCountryViewModel);
        }
        
        [HttpPost]
        public IActionResult Create(CreateCountryViewModel newCountry)
        {


            return PartialView();
        }
    }
}

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
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
    [Authorize(Roles = "Imperator")]
    public class CityController : Controller
    {
        private readonly ICityService _cityService;
        private readonly IPeopleService _peopleService;
        private readonly ICountryService _countryService;

        public CityController(ICityService cityService, IPeopleService peopleService, ICountryService countryService)
        {
            _cityService = cityService;
            _peopleService = peopleService;
            _countryService = countryService;
        }


        // GET: CityController
        public ActionResult Index()
        {
            CreateCityViewModel createCityView = new CreateCityViewModel();
            createCityView.cities = _cityService.All();

            return View(createCityView);
        }

        public IActionResult Search(CreateCityViewModel searchTerm)
        {
            searchTerm.cities = _cityService.Search(searchTerm.Search);
            return View("Index", searchTerm);
        }

        public IActionResult ClearSearch()
        {
            return RedirectToAction("Index");
        }

        // GET: CityController/Details/5
        public ActionResult Details(int id)
        {
            City city = _cityService.FindBy(id);
            if (city != null)
            {
                return View(city);
            }
            else
            {
                return NotFound();
            }

        }

        // GET: CityController/Create
        public ActionResult Create()
        {
            CreateCityViewModel createCityViewModel = new CreateCityViewModel();
            createCityViewModel.CountryList = _countryService.All();

            return View("CreateCity", createCityViewModel);
        }

        // POST: CityController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(CreateCityViewModel createCity)
        {

            try
            {
                if (createCity.Country != null)
                {
                    createCity.Country = _countryService.FindBy(createCity.Country.ID);
                    City city = _cityService.Add(createCity);
                    if (city != null)
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
                    return NotFound();
                }


            }
            catch
            {
                Response.StatusCode = 418;
                createCity.CountryList = _countryService.All();
                return View("CreateCity", createCity);
            }
        }

        // GET: CityController/Edit/5
        public ActionResult Edit(int id)
        {
            CreateCityViewModel createCityViewModel = new CreateCityViewModel();
            City city = _cityService.FindBy(id);
            if (city != null)
            {

                createCityViewModel.CountryList = _countryService.All();
                createCityViewModel.Id = id;
                createCityViewModel.Name = city.Name;
                if (city.Country != null)
                {
                    createCityViewModel.Country = city.Country;
                    return View(createCityViewModel);
                }
                else
                {
                    return View(createCityViewModel);
                }
            }
            else
            {
                return NotFound();
            }


        }

        // POST: CityController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, CreateCityViewModel createCityViewModel)
        {
            try
            {
                if (createCityViewModel.Country != null)
                {
                    createCityViewModel.Country = _countryService.FindBy(createCityViewModel.Country.ID);
                    City city = _cityService.FindBy(id);
                    if (city != null)
                    {
                        city.Name = createCityViewModel.Name;
                        city.Country = createCityViewModel.Country;

                        _cityService.Edit(city);
                        return RedirectToAction(nameof(Index));
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
            catch
            {
                Response.StatusCode = 418;
                return View();
            }
        }

        // GET: CityController/Delete/5
        public ActionResult Delete(int id)
        {
            City city = _cityService.FindBy(id);
            if (city != null)
            {
                city.CityPeopleList.Clear();
                _cityService.Edit(city);

                if (_cityService.Remove(id))
                {

                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    Response.StatusCode = 400;
                    return View();
                }
            }
            else
            {
                return NotFound();
            }
        }
    }
}

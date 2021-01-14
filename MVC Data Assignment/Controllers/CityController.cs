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
    public class CityController : Controller
    {
        public ICityService _cityService;
        public IPeopleService _peopleService;

        public CityController(ICityService cityService, IPeopleService peopleService)
        {
            _cityService = cityService;
            _peopleService = peopleService;
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
            //city.CityPeopleList = _peopleService.SearchCity(city.Id);

            return View(city);
        }

        // GET: CityController/Create
        public ActionResult Create()
        {
            CreateCityViewModel createCityViewModel = new CreateCityViewModel();
            return View("CreateCity", createCityViewModel);
        }

        // POST: CityController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(CreateCityViewModel createCity)
        {

            try
            {
                _cityService.Add(createCity);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                Response.StatusCode = 418;
                return View();
            }
        }

        // GET: CityController/Edit/5
        public ActionResult Edit(int id)
        {
            City city = _cityService.FindBy(id);
            return View(city);
        }

        // POST: CityController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, CreateCityViewModel createCityViewModel)
        {
            try
            {
                City city = new City(id, createCityViewModel.Name, createCityViewModel.Country, createCityViewModel.CityPeopleList);

                _cityService.Edit(city);
                return RedirectToAction(nameof(Index));
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
    }
}

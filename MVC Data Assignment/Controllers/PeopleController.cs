using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MVC_Data_Assignment.Models;
using MVC_Data_Assignment.Models.Services;

namespace MVC_Data_Assignment.Controllers
{
    public class PeopleController : Controller
    {
        private IPeopleService _peopleService = new PeopleService();

        [HttpGet]
        public IActionResult Index()
        {
            return View(_peopleService.All());
        }

        [HttpDelete]
        public IActionResult Index(int id)
        {
            _peopleService.Remove(id);
            return View(_peopleService.All());
        }

        [HttpPost]
        public IActionResult Index(string search)
        {
            if (search != null)
            {
                List<People> filterList = _peopleService.Search(search);
                return View(filterList);
            }
            else
            {
                return View(_peopleService.All());
            }  
        }

        [HttpPost]
        public IActionResult Search()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(CreatePersonViewModel personViewModel)
        {
            if (ModelState.IsValid)
            {
                _peopleService.Add(personViewModel);
                return RedirectToAction(nameof(Index));
            }

            return View(personViewModel);
        }

    }
}

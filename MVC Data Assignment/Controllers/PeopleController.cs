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

        public IActionResult Index()
        {
            return View(_peopleService.All());
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

        [HttpPost]
        public IActionResult Index(int id)
        {
            return View(_peopleService.FindBy(id));
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MVC_Data_Assignment.Models;
using MVC_Data_Assignment.Models.Services;
using MVC_Data_Assignment.Models.ViewModels;

namespace MVC_Data_Assignment.Controllers
{
    public class PeopleController : Controller
    {
        private IPeopleService _peopleService = new PeopleService();

        [HttpGet]
        public IActionResult Index()
        {
            PeoplesViewModel peoplesViewModel = new PeoplesViewModel();
            peoplesViewModel.peopleList = _peopleService.All();

            return View(peoplesViewModel);
        }

        [HttpPost]
        public IActionResult Index(PeoplesViewModel peoplesViewModel)
        {
            peoplesViewModel.peopleList = _peopleService.All();

            if (peoplesViewModel.Search != null)
            {
                peoplesViewModel.peopleList = _peopleService.Search(peoplesViewModel.Search);
                return View(peoplesViewModel);
            }
            else
            {
                return View(peoplesViewModel);
            }
        }

        public IActionResult Delete(int id)
        {
            PeoplesViewModel peoplesViewModel = new PeoplesViewModel();

            if (_peopleService.Remove(id))
            {
                peoplesViewModel.Msg = "Person Successfully Removed";
                peoplesViewModel.peopleList = _peopleService.All();
            }
            return View("Index", peoplesViewModel);
        }

        public IActionResult Create(PeoplesViewModel peoplesViewModel)
        {
            peoplesViewModel.peopleList = _peopleService.All();

            if (ModelState.IsValid)
            {
                _peopleService.Add(peoplesViewModel.CreatePerson);

                return RedirectToAction(nameof(Index));
            }

            peoplesViewModel.Msg = "Error: Required Fields not Filled in Correctly";
            return View("Index", peoplesViewModel);
        }

    }
}

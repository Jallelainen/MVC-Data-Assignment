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

        [HttpGet]
        public IActionResult AjaxCreate()
        {
            PeoplesViewModel peoplesViewModel = new PeoplesViewModel();
            return PartialView("_CreatePartial", peoplesViewModel.CreatePerson);
        }

        [HttpPost]
        public IActionResult AjaxCreatePost(CreatePersonViewModel createViewModel)
        {

            if (ModelState.IsValid)
            {
                Person person = _peopleService.Add(createViewModel);

                return PartialView("_ListItemPartial", person);
            }

            Response.StatusCode = 400;
            return PartialView("_CreatePartial", createViewModel);
        }

        [HttpGet]
        public IActionResult Edit(int Id)
        {
            PeoplesViewModel peoplesViewModel = new PeoplesViewModel();

            Person person = _peopleService.FindBy(Id);

            return PartialView("_EditPersonPartial", person);
        }

        [HttpPost]
        public IActionResult Edit(EditPersonViewModel editPersonViewModel, int id)
        {
            PeoplesViewModel peoplesViewModel = new PeoplesViewModel();
            Person person = _peopleService.FindBy(id);

            if (ModelState.IsValid)
            {
                _peopleService.Edit(id, editPersonViewModel);
                peoplesViewModel.peopleList = _peopleService.All();

                return PartialView("_ShowListPartial", peoplesViewModel.peopleList);

            }

            Response.StatusCode = 400;
            return PartialView("_EditPersonPartial", person);
        }

    }
}

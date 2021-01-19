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
        private IPeopleService _peopleService;
        private ICityService _cityService;
        private ILanguageService _languageService;

        public PeopleController(IPeopleService peopleService, ICityService cityService, ILanguageService languageService)
        {
            _peopleService = peopleService;
            _cityService = cityService;
            _languageService = languageService;

        }

        public IActionResult Index()
        {
            PeoplesViewModel peoplesViewModel = new PeoplesViewModel();
            peoplesViewModel.peopleList = _peopleService.All();

            return View(peoplesViewModel);
        }


        [HttpGet]
        public IActionResult ClearSearch()
        {
            PeoplesViewModel peoplesViewModel = new PeoplesViewModel();
            peoplesViewModel.peopleList = _peopleService.All();

            return PartialView("_ShowListPartial", peoplesViewModel.peopleList);
        }

        [HttpPost]
        public IActionResult Search(PeoplesViewModel peoplesViewModel)
        {

            if (peoplesViewModel.Search != null)
            {
                peoplesViewModel.peopleList = _peopleService.Search(peoplesViewModel.Search);
                return PartialView("_ShowListPartial", peoplesViewModel.peopleList);
            }
            else
            {
                peoplesViewModel.peopleList = _peopleService.All();
                return PartialView("_ShowListPartial", peoplesViewModel.peopleList);
            }
        }

        public IActionResult Delete(int id)
        {
            Person person = _peopleService.FindBy(id);

            if (person != null)
            {
                _peopleService.Remove(id);
                return RedirectToAction("Index");


            }
            else
            {
                return NotFound();
            }

        }

        [HttpGet]
        public IActionResult AjaxCreate()
        {
            CreatePersonViewModel createPersonViewModel = new CreatePersonViewModel();
            createPersonViewModel.cities = _cityService.All();
            return PartialView("_CreatePartial", createPersonViewModel);
        }

        [HttpPost]
        public IActionResult AjaxCreatePost(CreatePersonViewModel createViewModel)
        {
            PeoplesViewModel peoplesViewModel = new PeoplesViewModel();


            if (ModelState.IsValid)
            {
                if (createViewModel.City != null)
                {
                    createViewModel.City = _cityService.FindBy(createViewModel.City.Id);
                }
                _peopleService.Add(createViewModel);
                peoplesViewModel.peopleList = _peopleService.All();
                return View("Index", peoplesViewModel);
            }
            else
            {
                Response.StatusCode = 400;
                peoplesViewModel.peopleList = _peopleService.All();
                return View("Index", peoplesViewModel);

            }

        }

        [HttpGet]
        public IActionResult Edit(int Id)
        {

            Person person = _peopleService.FindBy(Id);

            if (person != null)
            {
                EditPersonViewModel editPerson = new EditPersonViewModel(Id, person, _languageService.All());
                editPerson.Cities = _cityService.All();
                return PartialView("_EditPersonPartial", editPerson);
            }
            else
            {
                return NotFound();
            }

        }

        [HttpPost]
        public IActionResult Edit(EditPersonViewModel editPersonViewModel, int id)
        {

            if (editPersonViewModel.City != null)
            {
                editPersonViewModel.City = _cityService.FindBy(editPersonViewModel.City.Id);
            }
            else
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                _peopleService.Edit(id, editPersonViewModel);

                return RedirectToAction("Index");

            }
            else
            {
                Response.StatusCode = 400;
                return PartialView("_EditPersonPartial", editPersonViewModel);
            }

        }

        public IActionResult Details(int id)
        {
            Person person = _peopleService.FindBy(id);
            if (person != null)
            {
                return PartialView("_PersonDetailPartial", person);
            }
            else
            {
                return NotFound();
            }

        }

        public IActionResult CloseDetails(int id)
        {
            Person person = _peopleService.FindBy(id);
            if (person != null)
            {
                return PartialView("_ListItemPartial", person);
            }
            else
            {
                return NotFound();
            }
        }
    }
}

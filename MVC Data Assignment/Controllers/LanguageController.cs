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
    public class LanguageController : Controller
    {
        private readonly ILanguageService _languageService;
        private readonly ICountryService _countryService;

        public LanguageController(ILanguageService languageService, ICountryService countryService)
        {
            _languageService = languageService;
            _countryService = countryService;
        }

        // GET: LanguageController
        public ActionResult Index()
        {
            LanguageViewModel languageViewModel = new LanguageViewModel();
            languageViewModel.Languages = _languageService.All();
            return View(languageViewModel);
        }

        // GET: LanguageController/Details/5
        public ActionResult Details(int id)
        {
            Language language = _languageService.FindBy(id);
            if (language != null)
            {
                return View(language);
            }
            else
            {
                return NotFound();
            }
        }

        // GET: LanguageController/Create
        public ActionResult Create()
        {
            LanguageViewModel languageViewModel = new LanguageViewModel();
            languageViewModel.Countries = _countryService.All();
            return View(languageViewModel);
        }

        // POST: LanguageController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(LanguageViewModel languageViewModel)
        {
            try
            {
                Language language = _languageService.Add(languageViewModel);
                if (language != null)
                {
                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    languageViewModel.Countries = _countryService.All();
                    return View(languageViewModel);
                }
            }
            catch
            {
                languageViewModel.Countries = _countryService.All();
                return View(languageViewModel);
            }
        }

        // GET: LanguageController/Edit/5
        public ActionResult Edit(int id)
        {
            Language language = _languageService.FindBy(id);
            if (language != null)
            {
                return View(language);
            }
            else
            {
                return NotFound();
            }
        }

        // POST: LanguageController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, LanguageViewModel languageViewModel)
        {
            try
            {
                Language language = _languageService.FindBy(id);

                if (languageViewModel.Country != null)
                {
                    language.Name = languageViewModel.Name;
                    language.Country = languageViewModel.Country;

                    if (_languageService.Edit(language) != null)
                    {
                        return RedirectToAction(nameof(Index));
                    }
                    else
                    {
                        return View(languageViewModel);
                    }
                }
                else
                {
                    language.Name = languageViewModel.Name;

                    if (_languageService.Edit(language) != null)
                    {
                        return RedirectToAction(nameof(Index));
                    }
                    else
                    {
                        return View(languageViewModel);
                    }
                }

            }
            catch
            {
                return View(languageViewModel);
            }
        }

        // GET: LanguageController/Delete/5
        public ActionResult Delete(int id)
        {
            Language language = _languageService.FindBy(id);
            if (language != null)
            {
                language.Speakers.Clear();
                _languageService.Edit(language);

                if (_languageService.Remove(id))
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


    }
}

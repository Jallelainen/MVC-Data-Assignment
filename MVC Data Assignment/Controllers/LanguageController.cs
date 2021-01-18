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
    public class LanguageController : Controller
    {
        public ILanguageService _languageService;

        public LanguageController(ILanguageService languageService)
        {
            _languageService = languageService;
        }

        // GET: LanguageController
        public ActionResult Index()
        {
            return View(_languageService.All());
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
                    return View(languageViewModel);
                }
            }
            catch
            {
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
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: LanguageController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: LanguageController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}

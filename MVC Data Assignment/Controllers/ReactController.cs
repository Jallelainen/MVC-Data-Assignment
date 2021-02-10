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
    [Route("api/[controller]")]
    [ApiController]
    public class ReactController : ControllerBase
    {
        private readonly IPeopleService _peopleService;
        private readonly ICityService _cityService;
        private readonly ICountryService _countryService;
        private readonly ILanguageService _languageService;
        public ReactController(IPeopleService peopleService, ICityService citiesService, ICountryService countriesService, ILanguageService languageService)
        {
            _peopleService = peopleService;
            _cityService = citiesService;
            _countryService = countriesService;
            _languageService = languageService;
        }

        // GET: api/<ReactController>
        [HttpGet]
        public ReactViewModel Get()
        {
            ReactViewModel reactViewModel = new ReactViewModel();

            reactViewModel.PeopleList = _peopleService.All();
            reactViewModel.Languages = _languageService.All();

            foreach (var person in reactViewModel.PeopleList)
            {
                person.City.CityPeopleList = null;
                person.City.Country = null;

                if (person.Languages != null)
                {
                    foreach (var language in person.Languages)
                    {
                        language.Person.City.CityPeopleList = null;
                    }
                }

            }

            foreach (var item in reactViewModel.Languages)
            {
                item.Speakers = null;
            }

            return reactViewModel;
        }

        // GET api/<ReactController>/1
        [HttpGet("{id}")]
        public Person Get(int id)
        {
            Person person = _peopleService.FindBy(id);

            if (person != null)
            {
                person.City.CityPeopleList = null;
                person.City.Country = null;

                foreach (var item in person.Languages)
                {
                    item.Person = null;
                    item.Language.Speakers = null;
                }

                return person;
            }

            return null;
        }

        // POST api/<ReactController>
        [HttpPost]
        public IActionResult Post(CreatePersonViewModel newPerson)
        {
            if (ModelState.IsValid)
            {
                Person person = _peopleService.Add(newPerson);
                return Created("Person added to database", person);
            }

            return BadRequest(newPerson);

        }

        //PUT api/<ReactController>/2
        [HttpPut("{id}")]//Edit person
        public IActionResult Edit(int id, [FromBody] EditPersonViewModel person)
        {

            if (ModelState.IsValid)
            {
                Person editedPerson = _peopleService.Edit(id, person);

                if (editedPerson == null)
                {
                    Response.StatusCode = 500;
                }

                return Ok(editedPerson);

            }

            return BadRequest(person);
        }

        // DELETE api/<ReactController>/3
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {

            if (_peopleService.Remove(id))
            {
                return Ok();
            }
            return BadRequest();
        }

    }
}

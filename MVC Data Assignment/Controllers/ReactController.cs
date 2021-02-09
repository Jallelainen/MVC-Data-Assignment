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
        public ReactController(IPeopleService peopleService, ICityService citiesService, ICountryService countriesService)
        {
            _peopleService = peopleService;
            _cityService = citiesService;
            _countryService = countriesService;
        }

        // GET: api/<ReactController>
        [HttpGet]
        public ReactViewModel Get()
        {
            ReactViewModel reactViewModel = new ReactViewModel();

            reactViewModel.PeopleList = _peopleService.All();
            reactViewModel.Languages = _languageService.All();

            return reactViewModel;
        }

        // GET api/<ReactController>/1
        [HttpGet("{id}")]
        public Person Get(int id)
        {
            return _peopleService.FindBy(id);
        }

        // POST api/<ReactController>
        [HttpPost]
        public void Post([FromBody] CreatePersonViewModel person)
        {
            //ToDo - code 201 created / code 400 bad request(validation failed) / code 500 database failed to create person
            _peopleService.Add(person);
        }

        //PUT api/<ReactController>/2
        [HttpPut("{id}")]//Edit person
        public void Edit(int id, EditPersonViewModel person)
        {
            //ToDo - code 200 ok was edited / code 400 bad request(validation failed) / code 500 database failed to save edit of person
            _peopleService.Edit(id, person);
        }

        // DELETE api/<ReactController>/3
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            //ToDo - code 200 was removed / code 404 not found / code 500 database failed to delete person
            _peopleService.Remove(id);
        }

    }
}

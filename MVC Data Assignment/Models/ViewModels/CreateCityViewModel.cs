using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVC_Data_Assignment.Models.ViewModels
{
    public class CreateCityViewModel
    {
        public string Name { get; set; }
        public Country Country { get; set; }
        public List<Person> CityPeopleList { get; set; }
    }
}

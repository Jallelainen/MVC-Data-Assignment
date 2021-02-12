using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVC_Data_Assignment.Models.ViewModels
{
    public class ReactViewModel
    {
        public IEnumerable<Person> PeopleList { get; set; }
        public IEnumerable<Language> Languages { get; set; }
        public IEnumerable<City> Cities { get; set; }


    }
}

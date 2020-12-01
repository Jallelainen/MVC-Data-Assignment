using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MVC_Data_Assignment.Models.ViewModels
{
    public class PeoplesViewModel
    {
        public string Search { get; set; }
        public string Msg { get; set; }
        public CreatePersonViewModel CreatePerson { get; set; }
        public EditPersonViewModel EditPerson { get; set; }
        public List<Person> peopleList { get; set; }
    }
}

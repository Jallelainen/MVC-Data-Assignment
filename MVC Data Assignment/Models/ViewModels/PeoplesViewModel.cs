using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVC_Data_Assignment.Models.ViewModels
{
    public class PeoplesViewModel
    {
        public string Search { get; set; }
        public CreatePersonViewModel CreatePerson { get; set; }
        public List<People> peopleList { get; set; }
    }
}

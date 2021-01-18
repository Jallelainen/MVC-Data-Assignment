using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MVC_Data_Assignment.Models.ViewModels
{
    public class LanguageViewModel
    {
        [Required]
        public string Name { get; set; }
        public string Search { get; set; }
        public Country Country { get; set; }
        public List<Country> Countries { get; set; }
    }
}

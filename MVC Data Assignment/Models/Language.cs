using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MVC_Data_Assignment.Models
{
    public class Language
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public Country Country { get; set; }
        public List<Person> Speakers { get; set; }

        public Language()
        {

        }

        public Language(string name, Country country)
        {
            Name = name;
            Country = country;
        }
    }
}

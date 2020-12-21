using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MVC_Data_Assignment.Models
{
    public class City
    {
        [Key]
        public string Name { get; set; }

        public Country Country { get; set; }

        public List<Person> CityPeopleList { get; set; }

    }
}

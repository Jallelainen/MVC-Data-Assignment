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
        public int Id { get; set; }
        public string Name { get; set; }

        public Country Country { get; set; }

        public List<Person> CityPeopleList { get; set; }

        public City() { }
        public City(string name, Country country, List<Person> cityPeople) 
        {
            Name = name;
            Country = country;
            CityPeopleList = cityPeople;
        }
        public City(int id, string name, Country country, List<Person> cityPeople) : this (name, country, cityPeople) { Id = id; }
    }
}

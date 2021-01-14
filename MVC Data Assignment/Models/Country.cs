﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MVC_Data_Assignment.Models
{
    public class Country
    {
        [Key]
        public int ID { get; set; }
        public string Name { get; set; }

        public List<City> CitiesList { get; set; }

        public Country () { }
        public Country (string name)
        {
            Name = name;
            
        }
    }
}
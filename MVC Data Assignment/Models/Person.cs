using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVC_Data_Assignment.Models
{
    public class Person
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string PhoneNum { get; set; }
        public City City { get; set; }

        public Person () { }
        public Person (string name, string phoneNum, City city) 
        {
            Name = name;
            PhoneNum = phoneNum;
            City = city;
        }
        public Person (int id, string name, string phoneNum, City city) : this (name, phoneNum, city) 
        {
            Id = id;
        }


    }
}

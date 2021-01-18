using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MVC_Data_Assignment.Models
{
    public class Person
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string PhoneNum { get; set; }
        public City City { get; set; }
        public List<Language> Languages { get; set; }

        public Person () { }
        public Person(string name, string phoneNum)
        {
            Name = name;
            PhoneNum = phoneNum;
        }
        public Person (string name, string phoneNum, City city) 
        {
            Name = name;
            PhoneNum = phoneNum;
            City = city;
        }
        public Person(int id, string name, string phoneNum)
        {
            Id = id;
            Name = name;
            PhoneNum = phoneNum;
        }

        public Person (int id, string name, string phoneNum, City city) : this (name, phoneNum, city) 
        {
            Id = id;
        }


    }
}

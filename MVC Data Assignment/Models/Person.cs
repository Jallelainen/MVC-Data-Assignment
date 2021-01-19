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
        public List<PersonLanguage> Languages { get; set; }

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
        public Person (string name, string phoneNum, List<PersonLanguage> languages) : this(name, phoneNum)
        {
            Languages = languages;
        }
        public Person (string name, string phoneNum, City city, List<PersonLanguage> languages) : this(name, phoneNum, city)
        {
            Languages = languages;
        }
        public Person(int id, string name, string phoneNum) : this (name, phoneNum)
        {
            Id = id;
        }

        public Person (int id, string name, string phoneNum, City city) : this (name, phoneNum, city) 
        {
            Id = id;
        }
        public Person (int id, string name, string phoneNum, List<PersonLanguage> languages) : this (id, name, phoneNum) 
        {
            Languages = languages;
        }
        public Person (int id, string name, string phoneNum, City city, List<PersonLanguage> languages) : this (id, name, phoneNum, city) 
        {
            Languages = languages;
        }


    }
}

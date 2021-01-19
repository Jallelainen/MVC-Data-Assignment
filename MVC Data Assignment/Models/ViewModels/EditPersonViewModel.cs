using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MVC_Data_Assignment.Models.ViewModels
{
    public class EditPersonViewModel
    {
        public int Id { get; set; }

        public Person person { get; set; }
        
        [Required]
        public string Name { get; set; }

        [Required]
        [Display(Name = "Phone Number")]
        [RegularExpression("^[0-9]{1,13}$", ErrorMessage = "Must only use numbers.")]
        public string PhoneNum { get; set; }
        public PersonLanguage PersonLanguage { get; set; }

        public City City { get; set; }

        public List<City> Cities { get; set; }
        public List<PersonLanguage> Languages { get; set; }
        public List<Language> PossibleLanguages { get; set; }


        public EditPersonViewModel()
        {

        }
        public EditPersonViewModel(int id, Person person)
        {
            Id = id;
            Name = person.Name;
            PhoneNum = person.PhoneNum;
            City = person.City;
        }

        public EditPersonViewModel(int id, Person person, List<Language> languageList) : this (id, person)
        {
            foreach (var item in person.Languages)
            {
                languageList.Remove(item.Language);
            }
            PossibleLanguages = languageList;
        }
    }
}

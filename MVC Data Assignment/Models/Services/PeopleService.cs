using MVC_Data_Assignment.Models.Data;
using MVC_Data_Assignment.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVC_Data_Assignment.Models.Services
{
    public class PeopleService : IPeopleService
    {
        IPeopleRepo _peopleRepo;
        ILanguageRepo _languageRepo;

        public PeopleService(IPeopleRepo peopleRepo, ILanguageRepo languageRepo)
        {
            _peopleRepo = peopleRepo;
            _languageRepo = languageRepo;
        }

        public Person Add(CreatePersonViewModel createPersonViewModel)
        {
            Person person = new Person(createPersonViewModel.Name, createPersonViewModel.PhoneNum);
            
            if (createPersonViewModel.City != null)
            {
                person.City = createPersonViewModel.City;
            }
            if (createPersonViewModel.PersonLanguage != null)
            {
                person.Languages = new List<PersonLanguage>();
                person.Languages.Add(createPersonViewModel.PersonLanguage);
            }
                _peopleRepo.Create(person);
                return person;
           
        }

        public List<Person> All()
        {
            return _peopleRepo.Read();
        }

        public Person Edit(int id, EditPersonViewModel editedPerson)
        {
            Person person = FindBy(id);

            person.Name = editedPerson.Name;
            person.PhoneNum = editedPerson.PhoneNum;
            if (editedPerson.City != null)
            {
                person.City = editedPerson.City;
            }
            if (editedPerson.PersonLanguage != null)
            {
                editedPerson.PersonLanguage.Language = _languageRepo.Read(editedPerson.PersonLanguage.Language.Id);
                person.Languages.Add(editedPerson.PersonLanguage);
            }

            return _peopleRepo.Update(person);
        }

        public Person FindBy(int id)
        {
            return _peopleRepo.Read(id);
        }

        public bool Remove(int id)
        {
            Person people = _peopleRepo.Read(id);

            if (people == null)
            {
                return false;
            }
            else
            {
                return _peopleRepo.Delete(people);
            }

        }

        public List<Person> Search(string search)
        {
            List<Person> filterList = new List<Person>();

            foreach (var item in All())
            {
                if (item.Name.ToUpper().Contains(search.ToUpper()) || item.PhoneNum.Contains(search) || item.City.Name.ToUpper().Contains(search.ToUpper())) //city.toString?
                {
                    filterList.Add(item);
                }
            }

            return filterList;
        }
        //public List<Person> SearchCity(int id)
        //{
        //    List<Person> filterList = new List<Person>();

        //    foreach (var item in All())
        //    {
        //        if (item.City.Id.ToString().Contains(id.ToString())) 
        //        {
        //            filterList.Add(item);
        //        }
        //    }

        //    return filterList;
        //}
    }
}

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
        
        public PeopleService(IPeopleRepo peopleRepo)
        {
            _peopleRepo = peopleRepo;
        }

        public Person Add(CreatePersonViewModel createPersonViewModel)
        {
            return _peopleRepo.Create(createPersonViewModel.Name, createPersonViewModel.PhoneNum, createPersonViewModel.City);
        }

        public List<Person> All()
        {
            return _peopleRepo.Read();
        }

        public Person Edit(int id, EditPersonViewModel people)
        {
            Person editedPeople = new Person( id, people.Name, people.PhoneNum, people.City);
            return _peopleRepo.Update(editedPeople);
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

                if (item.Name.ToUpper().Contains(search.ToUpper()) || item.PhoneNum.Contains(search) || item.City.ToUpper().Contains(search.ToUpper()))
                {
                    filterList.Add(item);
                }
            }

            return filterList;
        }
    }
}

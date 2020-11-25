using MVC_Data_Assignment.Models.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVC_Data_Assignment.Models.Services
{
    public class PeopleService : IPeopleService
    {
        IPeopleRepo _peopleRepo = new InMemoryPeopleRepo();

        public People Add(CreatePersonViewModel createPersonViewModel)
        {
            return _peopleRepo.Create(createPersonViewModel.Name, createPersonViewModel.PhoneNum, createPersonViewModel.City);
        }

        public List<People> All()
        {
            return _peopleRepo.Read();
        }

        public People Edit(int id, CreatePersonViewModel people)
        {
            People editedPeople = new People() { Id = id, Name = people.Name, PhoneNum = people.PhoneNum, City = people.City };
            return _peopleRepo.Update(editedPeople);
        }

        public People FindBy(int id)
        {
            return _peopleRepo.Read(id);
        }

        public bool Remove(int id)
        {
            People people = _peopleRepo.Read(id);

            if (people == null)
            {
                return false;
            }
            else
            {
                return _peopleRepo.Delete(people);
            }

        }
    }
}

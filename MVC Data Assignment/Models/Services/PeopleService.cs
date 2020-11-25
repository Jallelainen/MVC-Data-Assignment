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
            People editedPeople = new People( id, people.Name, people.PhoneNum, people.City);
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

        public List<People> Search(string search)
        {
            List<People> filterList = new List<People>();

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

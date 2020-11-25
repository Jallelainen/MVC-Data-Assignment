using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVC_Data_Assignment.Models.Data
{
    public class InMemoryPeopleRepo : IPeopleRepo
    {
        private static List<People> peopleList = new List<People>();
        private static int idCounter = 0;

        public People Create(string name, string phoneNum, string city)
        {
            People people = new People() { Id = ++idCounter, Name = name, PhoneNum = phoneNum, City = city };
            peopleList.Add(people);
            return people;
        }

        public bool Delete(People people)
        {
            return peopleList.Remove(people);
        }

        public List<People> Read()
        {
            return peopleList;
        }

        public People Read(int id)
        {
            foreach (People people in peopleList)
            {
                if (people.Id == id)
                {
                    return people;
                }
            }

            return null;
        }

        public People Update(People people)
        {
            People originalPeople = Read(people.Id);

            if (originalPeople == null)
            {
                return null;
            }

            originalPeople.Name = people.Name;
            originalPeople.PhoneNum = people.PhoneNum;
            originalPeople.City = people.City;

            return originalPeople;
        }
    }
}

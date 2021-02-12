using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVC_Data_Assignment.Models.Data
{
    public class InMemoryPeopleRepo 
    {
        private static List<Person> peopleList = new List<Person>();
        private static int idCounter = 0;

        public Person Create(string name, string phoneNum, City city)
        {
            Person people = new Person(++idCounter, name, phoneNum);
            peopleList.Add(people);
            return people;
        }

        public bool Delete(Person people)
        {
            return peopleList.Remove(people);
        }

        public List<Person> Read()
        {
            return peopleList;
        }

        public Person Read(int id)
        {
            foreach (Person people in peopleList)
            {
                if (people.Id == id)
                {
                    return people;
                }
            }

            return null;
        }

        public Person Update(Person people)
        {
            Person originalPeople = Read(people.Id);

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

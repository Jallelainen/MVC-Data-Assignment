using MVC_Data_Assignment.Models.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVC_Data_Assignment.Models.Data
{
    public class DataBasePeopleRepo : IPeopleRepo
    {
        private readonly PeopleDbContext _peopleDbContext;

        public DataBasePeopleRepo(PeopleDbContext peopleDbContext)
        {
            _peopleDbContext = peopleDbContext;
        }

        public Person Create(string name, string phoneNum, string city)
        {
            Person person = new Person(name, phoneNum, city);

            _peopleDbContext.PeopleList.Add(person);

            _peopleDbContext.SaveChanges();

            return person;
        }

        public bool Delete(Person people)
        {
            throw new NotImplementedException();
        }

        public List<Person> Read()
        {
            return _peopleDbContext.PeopleList.ToList();
        }

        public Person Read(int id)
        {
            return _peopleDbContext.PeopleList.SingleOrDefault( personList => personList.Id == id);
        }

        public Person Update(Person people)
        {
            throw new NotImplementedException();
        }
    }
}

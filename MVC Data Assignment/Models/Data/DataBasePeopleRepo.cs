﻿using Microsoft.EntityFrameworkCore;
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

        public Person Create(string name, string phoneNum)
        {
            Person lastId = _peopleDbContext.PeopleList.Last();//why?
            if (lastId != null)
            {
                Person person = new Person(lastId.Id++, name, phoneNum);
                
                _peopleDbContext.PeopleList.Add(person);

                if (_peopleDbContext.SaveChanges() != 0)
                {
                    return person;
                }
                else
                {
                    return null;
                }
            }
            else
            {
                int idCounter = 0;
                Person person = new Person(idCounter++, name, phoneNum);

                _peopleDbContext.PeopleList.Add(person);

                if (_peopleDbContext.SaveChanges() != 0)
                {
                    return person;
                }
                else
                {
                    return null;
                }
            }


        }

        public bool Delete(Person person)
        {
            if (person != null)
            {
                _peopleDbContext.PeopleList.Remove(person);

                if (_peopleDbContext.SaveChanges() != 0) // if previous line failed, no change was made
                {
                    return true;

                }
                else
                {
                    return false;
                }

            }
            else
            {
                return false;
            }

        }

        public List<Person> Read()
        {
            return _peopleDbContext.PeopleList.Include(p => p.City).ToList();
        }

        public Person Read(int id)
        {
            return _peopleDbContext.PeopleList.Include(p => p.City).SingleOrDefault(personList => personList.Id == id);
        }

        public Person Update(Person person)
        {
            Person originalPerson = Read(person.Id);

            if (originalPerson == null)
            {
                return null;
            }

            originalPerson.Name = person.Name;
            originalPerson.PhoneNum = person.PhoneNum;
            originalPerson.City = person.City;

            _peopleDbContext.PeopleList.Update(originalPerson);

            if (_peopleDbContext.SaveChanges() != 0)
            {
                return originalPerson;
            }
            else
            {
                return null;
            }
        }
    }
}

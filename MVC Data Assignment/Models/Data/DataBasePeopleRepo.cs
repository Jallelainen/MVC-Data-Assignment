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
        private readonly IdentityPersonDbContext _peopleDbContext;

        public DataBasePeopleRepo(IdentityPersonDbContext peopleDbContext)
        {
            _peopleDbContext = peopleDbContext;
        }

        public Person Create(Person person)
        {


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

        public bool Delete(Person person)
        {
            if (person != null)
            {
                _peopleDbContext.PeopleList.Remove(person);

                if (_peopleDbContext.SaveChanges() != 0) // if this failed, no changes was made
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
            return _peopleDbContext.PeopleList.Include(p => p.City).ThenInclude(p => p.Country).Include(p => p.Languages).ThenInclude(p => p.Language).SingleOrDefault(personList => personList.Id == id);
        }

        public Person Update(Person person)
        {
            

            if (person == null)
            {
                return null;
            }
            else
            {
                _peopleDbContext.PeopleList.Update(person);

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
    }
}

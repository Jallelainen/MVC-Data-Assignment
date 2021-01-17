using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVC_Data_Assignment.Models.Database
{
    public class PeopleDbContext : DbContext
    {
        //ctor
        public PeopleDbContext(DbContextOptions<PeopleDbContext> options) : base(options)
        {

        }


        //DbSet
        public DbSet<Person> PeopleList { get; set; } 
        public DbSet<City> CityList { get; set; } 
        public DbSet<Country> CountryList { get; set; } 
        public DbSet<Language> Languages { get; set; }
    }
}

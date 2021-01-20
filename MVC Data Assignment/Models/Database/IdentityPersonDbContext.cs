using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using MVC_Data_Assignment.Models.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVC_Data_Assignment.Models.Database
{
    public class IdentityPersonDbContext : IdentityDbContext<AppUser>
    {
        public IdentityPersonDbContext(DbContextOptions<IdentityPersonDbContext> options) : base(options) {}

        //DbSet
        public DbSet<Person> PeopleList { get; set; }
        public DbSet<City> CityList { get; set; }
        public DbSet<Country> CountryList { get; set; }
        public DbSet<Language> Languages { get; set; }
        public DbSet<PersonLanguage> PersonLanguage { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<PersonLanguage>()
                .HasKey(pl => new { pl.PersonId, pl.LanguageId });

            modelBuilder.Entity<PersonLanguage>()
                .HasOne(pl => pl.Person)
                .WithMany(p => p.Languages)
                .HasForeignKey(pl => pl.PersonId);

            modelBuilder.Entity<PersonLanguage>()
                .HasOne(pl => pl.Language)
                .WithMany(l => l.Speakers)
                .HasForeignKey(pl => pl.LanguageId);
        }
    }
}

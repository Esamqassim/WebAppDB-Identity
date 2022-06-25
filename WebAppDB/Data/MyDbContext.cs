using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAppDB.Models;

namespace WebAppDB.Data
{
    public class MyDbContext : IdentityDbContext<IdentityUser>
    {

        public MyDbContext(DbContextOptions<MyDbContext> options) : base(options)
        {
        }
        public DbSet<Person> Pepoles { get; set; }
        //
        public DbSet<City> Cities { get; set; }
        public DbSet<Country> Countries { get; set; }
        public DbSet<Language> Languages { get; set; }
        public DbSet<PeopleLanguage> PeopleLanguages { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);//Identity, Solve problem 

            modelBuilder.Entity<Person>().ToTable("Person");
            modelBuilder.Entity<City>().ToTable("City");
            modelBuilder.Entity<Country>().ToTable("Country");
            modelBuilder.Entity<Language>().ToTable("Language");

            //Many-To-Many configuration
            modelBuilder.Entity<PeopleLanguage>()
       .HasKey(bc => new { bc.Id, bc.LanguageID});

            modelBuilder.Entity<PeopleLanguage>()
       .HasOne(bc => bc.Person)
       .WithMany(b => b.PeopleLanguages)
       .HasForeignKey(bc => bc.Id);

            modelBuilder.Entity<PeopleLanguage>()
      .HasOne(bc => bc.Language)
      .WithMany(b => b.PeopleLanguages)
      .HasForeignKey(bc => bc.LanguageID);

            
            modelBuilder.Entity<Person>()
           .HasOne<City>(s => s.City)
           .WithMany(g => g.Persons)
           .HasForeignKey(s => s.CityID);

            modelBuilder.Entity<City>()
    .HasMany<Person>(g => g.Persons)
    .WithOne(s => s.City)
    .HasForeignKey(s => s.CityID)
    ;




        }//End OnModelCreating
    }
}

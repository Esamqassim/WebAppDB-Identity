﻿using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAppDB.Data;

namespace WebAppDB.Models
{
    public class DatabasePeopleRepo : IPeopleRepo
    {
        readonly MyDbContext _peopleDbContext;
        private static int idCounter = 0;

        //
        public DatabasePeopleRepo(MyDbContext peopleDbContext)
        {
            _peopleDbContext = peopleDbContext;
        
                       
        }//End constructor

        //Inital DB Not necessary 
        public static void Initialize(MyDbContext peopleDbContext)
        {
            peopleDbContext.Database.EnsureDeleted();
            peopleDbContext.Database.EnsureCreated();

           City blog = new City();
            Person comment = new Person();
            peopleDbContext.Entry(comment).State = EntityState.Added;


        }//End Initailize


            public Person Create(Person person)//Ok
        {
           // Initialize(_peopleDbContext);
            _peopleDbContext.Add(person);//?!
            _peopleDbContext.SaveChanges();
            return person;
        }

        public bool Delete(Person person)
        {
            //throw new NotImplementedException();
            _peopleDbContext.Pepoles.Remove(person);
            return (_peopleDbContext.SaveChanges()>0);
        }

        public List<Person> Read()//Ok work
        {
            /* return _peopleDbContext.Pepoles.Include(b => b)
                 .ToList();//Persons changed to Pepoles prperty in context
            */
            
            return _peopleDbContext.Pepoles.ToList();
        }
      

        public Person Read(int id)//Ok
        {
            /*
             return _peopleDbContext.Pepoles     //Not sure

                  .SingleOrDefault(book => book.Id == id);*/
            var city = _peopleDbContext.Pepoles.Find(id);
            return city;
        }

        public bool Update(Person person)
        {
            //throw new NotImplementedException();
            _peopleDbContext.Pepoles.Update(person);
            return (_peopleDbContext.SaveChanges() > 0);
        }
    }
}

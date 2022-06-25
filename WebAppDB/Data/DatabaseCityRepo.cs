using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAppDB.Models;

namespace WebAppDB.Data
{
    public class DatabaseCityRepo : ICityRepo
    {
        readonly MyDbContext _cityDbContext;

        public DatabaseCityRepo (MyDbContext cityDbContext)
        {
            _cityDbContext = cityDbContext;


        }//End constructor
        public City Create(City country)
        {
            _cityDbContext.Add(country);//?!
            _cityDbContext.SaveChanges();
            return country;
        }

        public bool Delete(City country)
        {
            if (country != null)
            {
                _cityDbContext.Remove(country);
                _cityDbContext.SaveChanges();
                return true;
            }

            else
                return false;
        }

        public List<City> Read()
        {
            return  _cityDbContext.Cities.ToList();
           // throw new NotImplementedException();
        }

        public City Read(int id)
        {
            var city = _cityDbContext.Cities.Find(id);  
           return city;
        }

        public bool Update(City country)
        {
            if (country != null)
            {
                _cityDbContext.Update(country);
                _cityDbContext.SaveChanges();
                return true;
            }

            else
                return false;
           
        }
    }
}

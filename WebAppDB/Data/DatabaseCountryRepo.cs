using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAppDB.Models;

namespace WebAppDB.Data
{
    public class DatabaseCountryRepo : ICountryRepo
    {
        readonly MyDbContext _countryDbContext;
        public DatabaseCountryRepo(MyDbContext countryDbContext)
        {
            _countryDbContext = countryDbContext;


        }//End constructor

        public Country Create(Country country)
        {
            _countryDbContext.Add(country);//?!
            _countryDbContext.SaveChanges();
            return country;
        }

        public bool Delete(Country country)
        {
            if (country != null)
            {
                _countryDbContext.Remove(country);
                _countryDbContext.SaveChanges();
                return true;
            }

            else
                return false;
        }

        public List<Country> Read()
        {
            // throw new NotImplementedException();
            return _countryDbContext.Countries.ToList();
        }

        public Country Read(int id)
        {
            var city = _countryDbContext.Countries.Find(id);
            return city;
        }

        public bool Update(Country country)
        {
            if (country != null)
            {
                _countryDbContext.Update(country);
                _countryDbContext.SaveChanges();
                return true;
            }

            else
                return false;
        }
    }
}

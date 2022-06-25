using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAppDB.Models;

namespace WebAppDB.Data
{
    public class DatabaseLanguageRepo : ILanguageRepo
    {
        readonly MyDbContext _languageDbContext;

        public DatabaseLanguageRepo(MyDbContext languageDbContext)
        {
            _languageDbContext = languageDbContext;


        }//End constructor
        public Language Create(Language country)
        {
            _languageDbContext.Add(country);//?!
            _languageDbContext.SaveChanges();
            return country;
        }

        public bool Delete(Language country)
        {
            if (country != null)
            {
                _languageDbContext.Remove(country);
                _languageDbContext.SaveChanges();
                return true;
            }

            else
                return false;
        }

        public List<Language> Read()
        {
            return _languageDbContext.Languages.ToList();
        }

        public Language Read(int id)
        {
            var city = _languageDbContext.Languages.Find(id);
            return city;
        }

        public bool Update(Language country)
        {
            if (country != null)
            {
                _languageDbContext.Update(country);
                _languageDbContext.SaveChanges();
                return true;
            }

            else
                return false;
        }
    }
}

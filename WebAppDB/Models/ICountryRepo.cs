using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAppDB.Models
{
   public interface ICountryRepo
    {
        //do sth
        Country Create(Country country);
        List<Country> Read();
        Country Read(int id);
        bool Update(Country country);
        bool Delete(Country country);
    }
}

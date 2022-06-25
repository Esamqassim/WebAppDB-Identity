using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAppDB.Models
{
  public  interface ICityRepo
    {
        //do sth
        City Create(City country);
         List<City> Read();
        City Read(int id);
        bool Update(City country);
        bool Delete(City country);
    }
}

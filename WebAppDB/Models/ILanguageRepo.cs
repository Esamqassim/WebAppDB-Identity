using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAppDB.Models
{
  public  interface ILanguageRepo
    {
        //do sth
       Language Create(Language country);
        List<Language> Read();
        Language Read(int id);
        bool Update(Language country);
        bool Delete(Language country);
    }
}

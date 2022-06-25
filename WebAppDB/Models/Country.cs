using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebAppDB.Models
{
    public class Country
    {
        [Key]
       public int CountryID { get; set; }
        public string CountryName { get; set; }
        //public int PersonId { get; set; }
         //public int CityID { get; set; }
         
         public ICollection<City>Citys { get; set; }
    }
}

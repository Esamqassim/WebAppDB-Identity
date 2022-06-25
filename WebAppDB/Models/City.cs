using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WebAppDB.Models
{
    public class City
    {
        [Key]
        
        public int CityID {
            get; set;
        }
        public string CityName { get; set; }
        public string CountryName { get; set; }
       // [ForeignKey("CountryID")]
       // public int CountryID { get; set; }

        public ICollection<Person>Persons { get; set; }

       
       
    }
}

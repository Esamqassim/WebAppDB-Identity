using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WebAppDB.Models
{
    public class Person
    {
        [Key]
       
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
        public string CityName { get; set; }//It should be deleted

        public string CountryName { get; set; }
        //[ForeignKey("CityID")]
        public int? CityID { get; set; }
        //[ForeignKey("CityID")]
        public City City { get; set; }
        //public City City = new City() { CityID = count++, CityName =""};
        //
        //[ForeignKey("LanguageID")]
        //public int LanguageID { get; set; }
        //public ICollection<Language> Languages { get; set; }//PepoleLanguage used instead
        public ICollection<PeopleLanguage> PeopleLanguages { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebAppDB.Models
{
    public class Language
    {
        [Key]
        public int LanguageID { get; set; }
        public string LanguageName { get; set; }
        // public ICollection<Person> Persons { get; set; }//PepoleLanguage used instead
        public ICollection<PeopleLanguage> PeopleLanguages { get; set; }
    }
}

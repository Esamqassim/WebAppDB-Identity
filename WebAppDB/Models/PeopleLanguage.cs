using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WebAppDB.Models
{
    public class PeopleLanguage
    {
        /*[Key]
        public int PeopleLanguageID{ get; set; }
        [ForeignKey("LanguageID")]
        public int LanguageID { get; set; }
        [ForeignKey("Id")]
        public int Id { get; set; }*/
        public int Id { get; set; }
        public Person Person { get; set; }

        public int LanguageID { get; set; }
        public Language Language { get; set; }
    }
}

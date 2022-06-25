using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAppDB.Identity;

namespace WebAppDB.ModelsLog
{
    public class ManageRolesViewModel
    {
        public IdentityRole Role { get; set; }

        // public IList<ApplicationUser> UserWithRole { get; set; }
        //public IList<ApplicationUser> UserNohRole { get; set; }

        public IList<IdentityUser> UserWithRole { get; set; }
        public IList<IdentityUser> UserNohRole { get; set; }
    }
}

using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAppDB.Data;
using WebAppDB.ModelsLog;

namespace WebAppDB.Identity
{
    public class AppUserStore : UserStore<IdentityUser>
    {
        private MyDbContext appDbContext;

        public AppUserStore(IdentityDbContext dbContext) : base(dbContext){ 
        
        }

        public AppUserStore(MyDbContext appDbContext)
        {
            this.appDbContext = appDbContext;
        }
    }
}

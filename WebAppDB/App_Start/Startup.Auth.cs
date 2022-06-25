using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Http;
using Microsoft.Owin.Security.Cookies;
using Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAppDB.Data;
using WebAppDB.Identity;
using WebAppDB.ModelsLog;

namespace WebAppDB.App_Start
{
    public class Startup
    {
        //Identity Configuration
        public void ConfigureAuth(IAppBuilder app)
        {
            app.UseCookieAuthentication(new Microsoft.Owin.Security.Cookies.CookieAuthenticationOptions()
            {
                AuthenticationType = DefaultAuthenticationTypes.ApplicationCookie,
                LoginPath = new Microsoft.Owin.PathString("/Account/Login")

            });
            this.CreateRoleUser();
        }

        public void CreateRoleUser()
        { /*
            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>());
            var appDbContext = new MyDbContext(null);
            var appUserStore = new AppUserStore(appDbContext);
            var userManager = new AppUserManager(appUserStore);

           // var userViewModel = new UserViewModel();

            //Create admin role

            if (!roleManager.RoleExists("Admin"))
            {
                var role = new IdentityRole();
                role.Name = "Admin";
                roleManager.Create(role);
            }

            //Create admin user

            if (userManager.FindByName("admin")==null)
            {
                var user= new UserViewModel();
                user.UserName = "admin";
                user.Email="admin@gmail.com";
                string passWord ="admin123";
                userManager.AddToRole(user.Id, "Admin");



            }

            //Create Manager role

            if (!roleManager.RoleExists("Manager"))
            {
                var role = new IdentityRole();
                role.Name = "Manager";
                roleManager.Create(role);
            }

            //Create admin user

            if (userManager.FindByName("manager") == null)
            {
                var user = new UserViewModel();
                user.UserName = "manager";
                user.Email = "manager@gmail.com";
                string passWord = "manager123";
                userManager.AddToRole(user.Id, "Admin");



            }


            //Create Costemer role

            if (!roleManager.RoleExists(" Coustemer"))
            {
                var role = new IdentityRole();
                role.Name = "Coustemer";
                roleManager.Create(role);
            }*/
        }
    }
}

using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAppDB.Identity;

namespace WebAppDB.Data
{
    internal class DbInitializer
    {
        internal static async Task InitializeAsync(
            MyDbContext context,
            RoleManager<IdentityRole> roleManager,
            UserManager<IdentityUser> userManager)
        {
            context.Database.EnsureCreated();
            //context.Database.Migrate();

            if (context.Roles.Any())//seed check
            {
                IdentityRole role = new IdentityRole("SuperAdmin");
                IdentityResult result = await roleManager.CreateAsync(role);
                if (!result.Succeeded)
                {
                    ErrorMessages(result);
                }
                //seed in the following into the Db SuperAdmin
                ApplicationUser appUser = new ApplicationUser
                {
                    FirstName = "Super",
                    LastName = "SuperAdmin",
                    BirthDate = DateTime.Now,
                    UserName = "SuperAdmin",
                    Email = "superadmin@admin.se"
                };
                IdentityResult userResult = await userManager.CreateAsync(appUser, "3MjaU64ByvLu7MU!!");
                if (!userResult.Succeeded)
                {
                    ErrorMessages(userResult);
                }
                userManager.AddToRoleAsync(appUser, role.Name).Wait();
            }
            //seed in the following into the Db SuperAdmin
            if (!context.Roles.Any(role => role.Name == "Admin"))
            {
                IdentityRole roleA = new IdentityRole("Admin");
                IdentityResult resultA = await roleManager.CreateAsync(roleA);

                if (!resultA.Succeeded)
                {
                    ErrorMessages(resultA);
                }
                //add user to role
                ApplicationUser appUser = new ApplicationUser
                {
                    FirstName = "Admina",
                    LastName = "Admin",
                    BirthDate = DateTime.Now,
                    UserName = "Admin",
                    Email = "admina@admin.se"
                };
                IdentityResult identityResult = await userManager.CreateAsync(appUser, "64Byv3MijaULu7MU!!");
                if (!identityResult.Succeeded)
                {
                    ErrorMessages(identityResult);
                }
                userManager.AddToRoleAsync(appUser, roleA.Name).Wait();
            }
        }

        private static void ErrorMessages(IdentityResult identityResult)
        {
            string errors = "";
            foreach (var error in identityResult.Errors)
            {
                errors += error.Code + ", " + error.Description;
            }
            throw new Exception(errors);
        }
    }
}

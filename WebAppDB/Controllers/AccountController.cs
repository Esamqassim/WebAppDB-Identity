using Microsoft.AspNet.Identity.Owin;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.WebUtilities;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Encodings.Web;
using System.Threading.Tasks;
using WebAppDB.Identity;
using WebAppDB.ModelsLog;

namespace WebAppDB.Controllers
{
    [AllowAnonymous]
    public class AccountController : Controller
    {
        private readonly SignInManager<IdentityUser> _signInManager;
        private readonly UserManager<IdentityUser> _userManager;
        private readonly ILogger<LoginViewModel> _logger;
        //Injection RoleManager
        private readonly RoleManager<IdentityRole> _roleManager;
        //
        [BindProperty]
        public UserViewModel Input { get; set; }

        //
        [BindProperty]
        public LoginViewModel InputUser { get; set; }

        //public string ReturnUrl { get; set; }

        // public IList<AuthenticationScheme> ExternalLogins { get; set; }


        public AccountController(UserManager<IdentityUser> userManager, ILogger<LoginViewModel> logger,
            SignInManager<IdentityUser> signInManager, RoleManager<IdentityRole> roleManager)
        {

            _userManager = userManager;
            _signInManager = signInManager;
            _logger= logger;
            _roleManager = roleManager;

        }

      
        public IActionResult Register()

        {
           
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(UserViewModel model)
        {
           // returnUrl = returnUrl ?? Url.Content("~/");
           // ExternalLogins = (await _signInManager.GetExternalAuthenticationSchemesAsync()).ToList();
            if (ModelState.IsValid)
            {
                var user = new ApplicationUser { UserName = model.UserName, Email = model.Email };
                var result = await _userManager.CreateAsync(user, model.Password);
                if (result.Succeeded)
                {
                    await _signInManager.SignInAsync(user, isPersistent: false);
                    //return Login();
                    return RedirectToAction(nameof(Login));
                    //return RedirectToAction("Index2", " Peoples");
                }
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                }
            }

            // If we got this far, something failed, redisplay form
            // return Register();
            return RedirectToAction(nameof(Register));
        }

        public async Task<IActionResult> Login()//Here will admin created
        {     
            //Create Admin Role
            //var role = new IdentityRole();
            //role.Name = "Admin";
           //  await _roleManager.CreateAsync(new IdentityRole("Admin"));

            //Create Admin user
            /*
                var user = new ApplicationUser();
                user.UserName = "Admin";
                //user.Email= "Admin";
                 user.Email = "admin@gmail.com";
                user.PasswordHash = "Admin123";
                //string passWord = "admin123";
                _userManager.AddToRoleAsync(user, "Admin");
                */
               // var user = new ApplicationUser { UserName = "admin@gmail.com", Email = "admin@gmail.com" ,PasswordHash= "Admin123" };
            //var result = await _userManager.AddToRoleAsync(user, "Admin");
           // _userManager.AddToRoleAsync(user, "Admin");
          


            return View();
        }

       

            /***First login template**/
            /*
            [HttpPost]
            public async Task<IActionResult> Login(string returnUrl = null)
            {
                returnUrl = returnUrl ?? Url.Content("~/");

                if (ModelState.IsValid)
                {
                    // This doesn't count login failures towards account lockout
                    // To enable password failures to trigger account lockout, set lockoutOnFailure: true
                    var result = await _signInManager.PasswordSignInAsync(InputUser.Email, InputUser.Password, true, false);
                    if (result.Succeeded)
                    {
                        // _logger.LogInformation("User logged in.");
                        //return LocalRedirect(returnUrl);
                       return RedirectToAction("Index2", " Peoples");
                        //return RedirectToAction(nameof(Index));

                    }


                    else
                    {
                        ModelState.AddModelError(string.Empty, "Invalid login attempt.");
                        return Register();
                       // return RedirectToAction(nameof(Register));
                    }
                }

                if (!ModelState.IsValid)
                {
                    return Register();
                }

                // If we got this far, something failed, redisplay form
                return Register();
                //return RedirectToAction(nameof(Register));
            }*/
            /**second Log in Template**/
            /*
            [HttpPost]
            [ValidateAntiForgeryToken]
            public async Task<ActionResult> Login(LoginViewModel model)
            {
                if (!ModelState.IsValid)
                {
                    return View(model);
                }



                Microsoft.AspNetCore.Identity.SignInResult result = await _signInManager.PasswordSignInAsync(model.Email, model.Password, true, false);


                //return RedirectToAction("Index2", "Pepoles");
                if (result.Succeeded)
                {

                    return RedirectToAction("Index2", "Pepoles");
                }

                return RedirectToAction(nameof(Register));

            }*/

            /*3rd log in Template**/
            // POST: /Account/Login
            [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Login(LoginViewModel model)
        {
            
            // This doesn't count login failures towards account lockout
            // To enable password failures to trigger account lockout, change to shouldLockout: true
            var result = await _signInManager.PasswordSignInAsync(model.UserName, model.Password, model.RememberMe, lockoutOnFailure: false);



            if (result.Succeeded)
            {
                //return RedirectToLocal(returnUrl); 
               // return RedirectToAction("Index2", " PeoplesController");
                return View("~/Views/Home/Index.cshtml");
            }
           
           
            else
            return View(model);           

        }

       
    }//End controller
}

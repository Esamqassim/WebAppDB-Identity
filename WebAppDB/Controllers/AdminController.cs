using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAppDB.ModelsLog;

//

using Microsoft.AspNetCore.Authorization;


namespace WebAppDB.Controllers
{
    public class AdminController : Controller
    {

        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly UserManager<IdentityUser> _userManager;
        public AdminController(RoleManager<IdentityRole> roleManager, UserManager<IdentityUser> userManager)
        {
            _roleManager = roleManager;
            _userManager = userManager;
        }
        public IActionResult Index()
        {
            return View(_roleManager.Roles.ToList());
        }

        //Create
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(string name)
        {
            IdentityRole role = new IdentityRole(name);
            var result = await _roleManager.CreateAsync(role);
            if (result.Succeeded)
            {
                return RedirectToAction("Index");
            }

            String message = ("Errors: ");

            //StringBuilder stringBuilder = new StringBuilder("Errors");
            foreach (var item in result.Errors)
            {
                //stringBuilder.Append(item.Description + " | ");
                message += item.Description + (" ");
            }
            ViewBag.Msg = message;
            //ViewBag.Msg = stringBuilder.ToString();
            return View();
        }

         [HttpGet]
        public async Task<IActionResult> ManageUserRoles(string id, string msg = null)
        {
            var role = await _roleManager.FindByIdAsync(id);
            if (role == null)
            {
                return RedirectToAction("Index");
            }
            ManageRolesViewModel rolesViewModel = new ManageRolesViewModel();

            rolesViewModel.Role = role;
            rolesViewModel.UserWithRole = await _userManager. GetUsersInRoleAsync(role.Name);
            rolesViewModel.UserNohRole = _userManager.Users.ToList();
            await _userManager.GetUsersInRoleAsync(role.Name);
            foreach (var item in rolesViewModel.UserWithRole)
            {
                rolesViewModel.UserNohRole.Remove(item);
            }

            ViewBag.Msg = msg;
            return View(rolesViewModel);
        }

        //Remove role

        [HttpGet]
        public async Task<IActionResult> RemoveFromRole(string userId, string roleId)
        {
            var role = await _roleManager.FindByIdAsync(roleId);
            if (role == null)
            {
                return RedirectToAction("Index");
            }
            var user = await _userManager.FindByIdAsync(userId);
            if (user == null)
            {
                return RedirectToAction("Index");
            }
            var result = await _userManager.RemoveFromRoleAsync(user, role.Name);
            if (result.Succeeded)
            {
                return RedirectToAction(nameof(ManageUserRoles), new { msg = " User have been successfully removed from the role", id = role.Id });
            }
            return RedirectToAction(nameof(ManageUserRoles), new { msg = " Remove the role from user, failed", id = role.Id });
        }

        //Add Role
        [HttpGet]
        public async Task<IActionResult> AddToRole(string userId, string roleId)
        {
            var role = await _roleManager.FindByIdAsync(roleId);
            if (role == null)
            {
                return RedirectToAction("Index");
            }
            var user = await _userManager.FindByIdAsync(userId);
            if (user == null)
            {
                return RedirectToAction("Index");
            }
            var result = await _userManager.AddToRoleAsync(user, role.Name);
            if (result.Succeeded)
            {
                return RedirectToAction(nameof(ManageUserRoles), new { msg = " User have been successfully added to the role", id = role.Id });
            }
            return RedirectToAction(nameof(ManageUserRoles), new { msg = " Add role to user failed", id = role.Id });
        }
    }
}

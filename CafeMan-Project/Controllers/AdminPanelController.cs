using CafeMan_Project.Models.Dal;
using CafeMan_Project.Models.Entities;
using CafeMan_Project.Models.ViewModels;
using CafeMan_Project.Repositories;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Data;

namespace CafeMan_Project.Controllers
{
    public class AdminPanelController : Controller
    {
        private readonly UserManager<User> userManager;
        private readonly RoleManager<IdentityRole> roleManager;
        private readonly ICafeRepository<Cafe> cafeRepo;

        public AdminPanelController(UserManager<User> userManager, RoleManager<IdentityRole> roleManager, ICafeRepository<Cafe> cafeRepo)
        {
            this.userManager = userManager;
            this.roleManager = roleManager;
            this.cafeRepo = cafeRepo;        
        }

        public async Task<IActionResult> Info()
        {
            var users = await userManager.Users.ToListAsync();
            var cafes = await cafeRepo.GetOwnerCafe();
            var admins = await userManager.GetUsersInRoleAsync("Admin");

            var model = new AdminVM()
            {
                Cafes = cafes,
                Users = users,
                Admins = admins
            };

            return View(model);
        }

        
        public async Task<IActionResult> EditUser(string id)
        {
            var user = await userManager.FindByIdAsync(id);

            var model = new EditUserVM()
            {
                Email = user.Email,
                Id = user.Id
            };
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> EditUser([Bind("Id","Email", "CurrentPassword", "Password", "RepeatPassword")]EditUserVM model)
        {
            var user = await userManager.FindByIdAsync(model.Id);

            if (ModelState.IsValid)
            {
                user.Email = model.Email;
                user.UserName = model.Email;
                await userManager.UpdateAsync(user);
                var result = await userManager.ChangePasswordAsync(user,model.CurrentPassword,model.Password);

                if (result.Succeeded) 
                    return RedirectToAction("Info");
            }
            return View(model);
        }


        [HttpPost]
        public async Task<IActionResult> RemoveUser(string id)
        {
            var user = await userManager.FindByIdAsync(id);
            await userManager.DeleteAsync(user);

            return RedirectToAction("Info");
        }


        [HttpPost]
        public async Task<IActionResult> RemoveCafe(int id)
        {
            await cafeRepo.Delete(id);

            return RedirectToAction("Info");
        }


        public async Task<IActionResult> EditRole(string id)
        {
            var user = await userManager.FindByIdAsync(id);
            var userRoles = (await userManager.GetRolesAsync(user)).ToList();
            var roles = await roleManager.Roles.ToListAsync();

            var model = new RoleEditVM()
            {
                CurentUser = user,
                AllRoles = roles,
                UserRoles = userRoles
            };

            return View(model);
        }


        [HttpPost]
        public async Task<IActionResult> EditRole(RoleEditVM model)
        {
            var user = await userManager.FindByIdAsync(model.Id);
            var roles = await roleManager.Roles.ToListAsync();

            foreach (var role in roles)
            {
                if (model.Roles.Contains(role.Name))
                {
                    if (!(await userManager.IsInRoleAsync(user, role.Name)))
                    {
                        await userManager.AddToRoleAsync(user, role.Name);
                    }
                }
                else
                {
                    if (await userManager.IsInRoleAsync(user, role.Name))
                    {
                        await userManager.RemoveFromRoleAsync(user, role.Name);
                    }
                }
            }
            return RedirectToAction("Info");
        }


    }
}

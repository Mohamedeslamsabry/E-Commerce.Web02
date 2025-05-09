using Admin_DashBord.Models.Roles;
using Admin_DashBord.Models.Users;
using Domain_Layer.Exceptions;
using Domain_Layer.Models.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace Admin_DashBord.Controllers
{
    public class UserController(UserManager<ApplicationUser> _userManager, RoleManager<IdentityRole> _roleManager) : Controller
    {
        #region Index
        public async Task<IActionResult> Index()
        {
            var Users = await _userManager.Users.Select(U => new UserViewModel()
            {
                DisplayName = U.DisplayName,
                Email = U.Email!,
                Id = U.Id,
                PhoneNumber = U.PhoneNumber!,
                UserName = U.UserName!,
                Roles = _userManager.GetRolesAsync(U).Result
            }).ToListAsync();

            return View(Users);
        }
        #endregion

        #region Edit
        [HttpGet]
        public async Task<IActionResult> Edit(string Id)
        {
            var User = await _userManager.FindByIdAsync(Id) ?? throw new UserNotFoundException(Id);

            var AllRole = await _roleManager.Roles.ToListAsync();
            // To Display All role In application

            var UserView = new UserRoleViewModel()
            {
                UserName = User.UserName!,
                UserId = User.Id,
                Roles = AllRole.Select(r => new RoleEditViewModel()
                {
                    Id = r.Id,
                    Name = r.Name!,
                    IsSelected = _userManager.IsInRoleAsync(User, r.Name!).Result
                }).ToList()
            };
            return View(UserView);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(UserRoleViewModel model)
        {

            var User = await _userManager.FindByIdAsync(model.UserId) ?? throw new UserNotFoundException(model.UserName);

            foreach (var role in model.Roles)
            {
                if (await _userManager.IsInRoleAsync(User, role.Name) && !role.IsSelected)
                {
                    await _userManager.RemoveFromRoleAsync(User, role.Name);
                }
                if (!await _userManager.IsInRoleAsync(User, role.Name) && role.IsSelected)
                {
                    await _userManager.AddToRoleAsync(User, role.Name);
                }
            }

            return RedirectToAction(nameof(Index));



        }
        #endregion
    }
}

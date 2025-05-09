using Admin_DashBord.Models.Users;
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
    }
}

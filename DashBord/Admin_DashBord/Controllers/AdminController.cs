using Domain_Layer.Exceptions;
using Domain_Layer.Models.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Shared.DTO.Identity;
using System.Threading.Tasks;

namespace Admin_DashBord.Controllers
{
    public class AdminController(SignInManager<ApplicationUser> _signInManager , UserManager<ApplicationUser> _userManager) : Controller
    {
        #region Login
        [HttpGet]
        public IActionResult Login()
        {            
            return View(new LoginDTO());
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginDTO loginDTO)
        {
            if (ModelState.IsValid)
            {
                var User = await _userManager.FindByEmailAsync(loginDTO.Email);

                if(User is null)
                {
                    ModelState.AddModelError("", "Invaild User");
                    return RedirectToAction(nameof(Login));
                }
                var result = await _signInManager.PasswordSignInAsync(User, loginDTO.Password,false,false);
                if (!result.Succeeded || !await _userManager.IsInRoleAsync(User,"Admin"))
                {
                    ModelState.AddModelError("", "You Are Not Authorized");
                    return RedirectToAction(nameof(Login));
                }
                return RedirectToAction("Index","Home");
            }
            ModelState.AddModelError("", "Try again");
            return RedirectToAction(nameof(Login));
        }

        #endregion

        #region Logout
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction(nameof(Login));
        }
        #endregion

    }
}

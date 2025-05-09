using Admin_DashBord.Models.Roles;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace Admin_DashBord.Controllers
{
    public class RoleController(RoleManager<IdentityRole> _roleManager) : Controller
    {
        #region Index
        //All Roles
        public async Task<IActionResult> Index()
        {
            var Roles = await _roleManager.Roles.ToListAsync();
            return View(Roles);
        }
        #endregion

        #region Create

        [HttpPost]
        public async Task<IActionResult> Create(RoleFormViewModel model)
        {
            if (ModelState.IsValid)
            {
                var RoleExist = await _roleManager.RoleExistsAsync(model.Name);
                if (!RoleExist)
                {
                    await _roleManager.CreateAsync(new IdentityRole(model.Name));
                    return RedirectToAction(nameof(Index));
                }
                ModelState.AddModelError(string.Empty, "Role Alrady exist");
                return View(nameof(Index),await _roleManager.Roles.ToListAsync());
            }
            ModelState.AddModelError(string.Empty, "Try Again");
            return RedirectToAction(nameof(Index));
        }


        #endregion

        #region Delete
        public async Task<IActionResult> Delete(string id)
        {
            var role = await _roleManager.FindByIdAsync(id);
            if (role is not null)
            {
                await _roleManager.DeleteAsync(role);
            }
            return RedirectToAction(nameof(Index));
        }
        #endregion

        #region Edit
        [HttpGet]
        public async Task<IActionResult> Edit(string id)
        {
            var role = await _roleManager.FindByIdAsync(id);
            if (role is null)
            {
                ModelState.AddModelError(string.Empty, "No Role Found Wit This Id");
                return RedirectToAction(nameof(Index));
            }
            var EditRole = new RoleEditViewModel()
            {
                Id = role.Id,
                Name = role.Name!
            };
            return View(EditRole);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(RoleEditViewModel model)
        {
            if (ModelState.IsValid)
            {
                var RoleExist = await _roleManager.RoleExistsAsync(model.Name);
                if (!RoleExist)
                {
                    var role = await _roleManager.FindByIdAsync(model.Id);
                    if (role is not null)
                    {
                        role.Name = model.Name;
                        await _roleManager.UpdateAsync(role);
                    }
                    return RedirectToAction(nameof(Index));
                }
                ModelState.AddModelError(string.Empty, "Role Alrady exist");
                return View(nameof(Index), await _roleManager.Roles.ToListAsync());
            }
            ModelState.AddModelError(string.Empty, "Try Again");
            return RedirectToAction(nameof(Index));
        }

        #endregion

    }
}

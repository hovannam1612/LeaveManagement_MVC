using LeaveManagement.WebApp.Data.Entities;
using LeaveManagement.WebApp.Interfaces.IServices;
using LeaveManagement.WebApp.Models.ViewModels.Employees;
using LeaveManagement.WebApp.Utils.Constants;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LeaveManagement.WebApp.Areas.Admin.Controllers
{
    public class AccountsController : BaseController
    {
        private readonly IUserService _userService;
        private readonly UserManager<Employee> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly ILogger<AccountsController> _logger;

        public AccountsController(
            IUserService userService,
            ILogger<AccountsController> logger,
            UserManager<Employee> userManager,
            RoleManager<IdentityRole> roleManager
            )
        {
            _userService = userService;
            _logger = logger;
            _userManager = userManager;
            _roleManager = roleManager;
        }

        [TempData]
        public string StatusMessage { get; set; }

        public async Task<IActionResult> Index()
        {
            var users = await _userService.GetUsersAsync();
            return View(users);
        }

        public async Task<IActionResult> SetPassword(string id)
        {
            var user = await _userManager.FindByIdAsync(id);
            if (user == null)
            {
                return NotFound("User is not found");
            }
            ViewData["UserName"] = user.UserName;

            var setPassword = new SetPasswordVM()
            {
                Id = user.Id,
            };
            return View(setPassword);
        }

        [HttpPost]
        public async Task<IActionResult> SetPassWord(SetPasswordVM setPassword)
        {
            var user = await _userManager.FindByIdAsync(setPassword.Id);
            if (user == null)
            {
                return NotFound($"Unable to load user with ID '{_userManager.GetUserId(User)}'.");
            }
            if (!ModelState.IsValid)
            {
                return View(setPassword);
            }

            await _userManager.RemovePasswordAsync(user);
            var addPasswordResult = await _userManager.AddPasswordAsync(user, setPassword.NewPassword);
            if (!addPasswordResult.Succeeded)
            {
                addPasswordResult.Errors.ToList().ForEach(error =>
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                });
                return View(setPassword);
            }
            StatusMessage = $"Password update successful for user: {user.UserName}";
            return RedirectToAction("Index", "Accounts");
        }

        public async Task<IActionResult> AddRole(string id)
        {
            if (string.IsNullOrEmpty(id))
            {
                return NotFound($"User is not found");
            }

            var user = await _userManager.FindByIdAsync(id);

            if (user == null)
            {
                return NotFound($"User is not found, id = {id}.");
            }
            var roleNames = (await _userManager.GetRolesAsync(user)).ToArray<string>();

            var userVM = new UserVM();
            userVM.UserName = user.UserName;
            userVM.Id = user.Id;
            userVM.RoleNames = roleNames;

            List<string> allRoleNames = await _roleManager.Roles.Select(r => r.Name).ToListAsync();
            userVM.AllRoles = new SelectList(allRoleNames);

            return View(userVM);
        }

        [HttpPost]
        public async Task<IActionResult> AddRole(UserVM userVM)
        {
            if (userVM == null)
            {
                return NotFound($"User is not found");
            }

            var user = await _userManager.FindByIdAsync(userVM.Id);
            if (user == null)
            {
                return NotFound($"User is not found, id = {userVM.Id}.");
            }

            var OldRoleNames = (await _userManager.GetRolesAsync(user)).ToArray();

            var deleteRoles = OldRoleNames.Where(r => !userVM.RoleNames.Contains(r));
            var addRoles = userVM.RoleNames.Where(r => !OldRoleNames.Contains(r));

            List<string> allRoleNames = await _roleManager.Roles.Select(r => r.Name).ToListAsync();
            userVM.AllRoles = new SelectList(allRoleNames);

            var resultDelete = await _userManager.RemoveFromRolesAsync(user, deleteRoles);
            if (!resultDelete.Succeeded)
            {
                resultDelete.Errors.ToList().ForEach(error =>
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                });
                return View();
            }

            var resultAdd = await _userManager.AddToRolesAsync(user, addRoles);

            if (!resultAdd.Succeeded)
            {
                resultAdd.Errors.ToList().ForEach(error =>
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                });
                return View();
            }

            StatusMessage = $"Role update successful for user: {user.UserName}";

            return RedirectToAction("Index", "Accounts");

        }

        public async Task<IActionResult> DeleteAllRoles(string id)
        {
            if (string.IsNullOrEmpty(id))
                return NotFound($"User is not found");

            var user = await _userManager.FindByIdAsync(id);

            if (user == null)
                return NotFound($"User is not found, id = {id}.");

            var OldRoleNames = (await _userManager.GetRolesAsync(user)).ToArray();

            var resultDelete = await _userManager.RemoveFromRolesAsync(user, OldRoleNames);
            if (!resultDelete.Succeeded)
            {
                resultDelete.Errors.ToList().ForEach(error =>
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                });

            }
            StatusMessage = $"Delete successfully all roles of user: {user.UserName}";
            return RedirectToAction("Index", "Accounts");
        }

        public async Task<IActionResult> DeleteUser(string id)
        {
            if (string.IsNullOrEmpty(id))
                return NotFound($"Not Found");

            var user = await _userManager.FindByIdAsync(id);

            if (user == null)
                return NotFound($"Not Found");

            
            var resultDelete = await _userManager.DeleteAsync(user);

            if (!resultDelete.Succeeded)
            {
                resultDelete.Errors.ToList().ForEach(error =>
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                });
            }
            StatusMessage = $"Delete successfully user: {user.UserName}";
            return RedirectToAction("Index", "Accounts");
        }
    }
}
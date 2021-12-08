using LeaveManagement.WebApp.Data.Entities;
using LeaveManagement.WebApp.Interfaces.IServices;
using LeaveManagement.WebApp.Models.ViewModels.Roles;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Linq;
using System.Threading.Tasks;

namespace LeaveManagement.WebApp.Areas.Admin.Controllers
{
    public class RolesController : BaseController
    {
        private readonly IUserService _userService;
        private readonly ILogger<RolesController> _logger;
        private readonly UserManager<Employee> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        public RolesController(
            IUserService userService,
            ILogger<RolesController> logger,
            UserManager<Employee> userManager,
            RoleManager<IdentityRole> roleManager
            )
        {
            _userService = userService;
            _userManager = userManager;
            _roleManager = roleManager;
            _logger = logger;
        }

        [TempData]
        public string StatusMessage { get; set; }

        public IActionResult Index()
        {
            var roles = _userService.GetRoles();
            return View(roles);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(RoleVM role)
        {
            if (!ModelState.IsValid)
            {
                return View(role);
            }

            var newRole = new IdentityRole(role.Name);
            var result = await _roleManager.CreateAsync(newRole);
            if (result.Succeeded)
            {
                StatusMessage = $"Created: {role.Name}";
                return RedirectToAction("Index", "Roles");
            }
            else
            {
                result.Errors.ToList().ForEach(error =>
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                });
            }
            return View(role);
        }

        public async Task<IActionResult> Update(string id)
        {
            var role = await _roleManager.FindByIdAsync(id);
            if (role != null)
            {
                var roleVM = new RoleVM()
                {
                    Id = role.Id,
                    Name = role.Name
                };
                return View(roleVM);
            }
            return NotFound("Role name is not found");
        }

        [HttpPost]
        public async Task<IActionResult> Update(RoleVM role)
        {
            if (!ModelState.IsValid)
            {
                return View(role);
            }

            if (role == null)
                return NotFound("Role name is not found");
            var roleUpdate = await _roleManager.FindByIdAsync(role.Id);
            roleUpdate.Name = role.Name;

            var result = await _roleManager.UpdateAsync(roleUpdate);

            if (result.Succeeded)
            {
                StatusMessage = $"Role name has been changed: {roleUpdate.Name}";
                return RedirectToAction("Index", "Roles");
            }
            else
            {
                result.Errors.ToList().ForEach(error =>
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                });
            }
            return View(role);
        }

        public async Task<IActionResult> Delete(string id)
        {
            if (id == null) return NotFound("Role name is not found");

            var role = await _roleManager.FindByIdAsync(id);
            if (role == null) return NotFound("Role name is not found");


            var result = await _roleManager.DeleteAsync(role);

            if (result.Succeeded)
            {
                StatusMessage = $"Role name has been deleted: {role.Name}";
                return RedirectToAction("Index", "Roles");
            }
            else
            {
                result.Errors.ToList().ForEach(error =>
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                });
            }
            return RedirectToAction("Index", "Roles");
        }
    }
}
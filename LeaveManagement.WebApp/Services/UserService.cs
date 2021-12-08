using LeaveManagement.WebApp.Data.Entities;
using LeaveManagement.WebApp.Interfaces.IServices;
using LeaveManagement.WebApp.Models.ViewModels.Employees;
using LeaveManagement.WebApp.Models.ViewModels.Roles;
using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LeaveManagement.WebApp.Services
{
    public class UserService : IUserService
    {
        private readonly UserManager<Employee> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        public UserService(
            UserManager<Employee> userManager,
            RoleManager<IdentityRole> roleManager
            )
        {
            _userManager = userManager;
            _roleManager = roleManager;
        }

        public IEnumerable<RoleVM> GetRoles()
        {
            var roles = _roleManager.Roles.ToList();
            var listVm = new List<RoleVM>();
            foreach (var item in roles)
            {
                var rm = new RoleVM()
                {
                    Name = item.Name,
                    Id = item.Id
                };
                listVm.Add(rm);
            }
            return listVm;
        }

        public async Task<IEnumerable<UserVM>> GetUsersAsync()
        {
            var users = _userManager.Users;

            var vmList = new List<UserVM>();
            foreach (var user in users)
            {
                var vm = await GetUserDetail(user.Id);
                vmList.Add(vm);
            }
            return vmList;
        }

        public async Task<UserVM> GetUserDetail(string userId)
        {
            var user = await _userManager.FindByIdAsync(userId);
            if (user != null)
            {
                var roles = await _userManager.GetRolesAsync(user);
                var response = new UserVM()
                {
                    Id = user.Id,
                    Email = user.Email,
                    UserName = user.UserName,
                    Firstname = user.Firstname,
                    Lastname = user.Lastname,
                    RoleNames = roles.ToArray<string>()
                };

                return response;
            }
            return null;
        }
    }
}
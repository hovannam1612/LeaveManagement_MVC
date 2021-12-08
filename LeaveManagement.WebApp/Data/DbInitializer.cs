using LeaveManagement.WebApp.Data.Entities;
using LeaveManagement.WebApp.Utils.Constants;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LeaveManagement.WebApp.Data
{
    public class DbInitializer
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<Employee> _userManager;

        public DbInitializer(ApplicationDbContext context, UserManager<Employee> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        public async Task Seed()
        {
            _context.Database.EnsureCreated();

            var roleStore = new RoleStore<IdentityRole>(_context);

            if (!_context.Roles.Any())
            {
                var admin = new IdentityRole() { Name = UserRole.Admin, NormalizedName = UserRole.Admin.ToUpper() };
                var user = new IdentityRole() { Name = UserRole.Employee, NormalizedName = UserRole.Employee.ToUpper() };
                await roleStore.CreateAsync(user);
                await roleStore.CreateAsync(admin);
            }
            if (!_context.Users.Any())
            {
                //Create admin
                var admin = new Employee() { UserName = "admin", Email = "admin@gmail.com" };
                var result = await _userManager.CreateAsync(admin, "123456");
                if (result.Succeeded)
                {
                    //add role
                    List<string> roles = new List<string>();
                    roles.Add(UserRole.Admin);
                    await _userManager.AddToRolesAsync(admin, roles);
                }
            }
            await _context.SaveChangesAsync();
        }
    }
}
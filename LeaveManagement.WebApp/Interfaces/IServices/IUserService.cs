using LeaveManagement.WebApp.Models.ViewModels.Employees;
using LeaveManagement.WebApp.Models.ViewModels.Roles;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LeaveManagement.WebApp.Interfaces.IServices
{
    public interface IUserService
    {
        Task<IEnumerable<UserVM>> GetUsersAsync();

        IEnumerable<RoleVM> GetRoles();
       
    }
}
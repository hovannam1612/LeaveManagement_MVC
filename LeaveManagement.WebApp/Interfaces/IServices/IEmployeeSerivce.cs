using LeaveManagement.WebApp.Models.ViewModels.Employees;
using LeaveManagement.WebApp.Models.ViewModels.LeaveAllocations;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LeaveManagement.WebApp.Interfaces.IServices
{
    public interface IEmployeeService
    {
        Task<IEnumerable<EmployeeVM>> GetAllAsync();

        Task<ViewAllocationsVM> Detail(string employeeId);
    }
}
using LeaveManagement.WebApp.Models.ViewModels.Employees;
using System.Collections.Generic;

namespace LeaveManagement.WebApp.Models.ViewModels.LeaveAllocations
{
    public class ViewAllocationsVM
    {
        public EmployeeVM Employee { get; set; }

        public string EmployeeId { get; set; }
        
        public IEnumerable<LeaveAllocationVM> LeaveAllocations { get; set; }
    }
}
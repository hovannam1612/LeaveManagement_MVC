using LeaveManagement.WebApp.Models.ViewModels.LeaveAllocations;
using System.Collections.Generic;

namespace LeaveManagement.WebApp.Models.ViewModels.LeaveRequests
{
    public class EmployeeLeaveRequestViewVM
    {
        public List<LeaveAllocationVM> LeaveAllocations { get; set; }

        public List<LeaveRequestVM> LeaveRequests { get; set; }
    }
}
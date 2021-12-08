using LeaveManagement.WebApp.Models.ViewModels.Employees;
using LeaveManagement.WebApp.Models.ViewModels.LeaveTypes;
using System;

namespace LeaveManagement.WebApp.Models.ViewModels.LeaveAllocations
{
    public class CreateLeaveAllocationVM
    {
        public int NumberOfDays { get; set; }

        public EmployeeVM Employee { get; set; }

        public int Period { get; set; }

        public string EmployeeId { get; set; }

        public LeaveTypeVM LeaveType { get; set; }

        public Guid LeaveTypeId { get; set; }

        public DateTime CreatedOn { get; set; }

        public DateTime UpdatedOn { get; set; }
    }
}
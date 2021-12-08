using LeaveManagement.WebApp.Models.ViewModels.Employees;
using LeaveManagement.WebApp.Models.ViewModels.LeaveTypes;
using System;
using System.Collections.Generic;

namespace LeaveManagement.WebApp.Models.ViewModels.LeaveAllocations
{
    public class LeaveAllocationVM
    {
        public Guid Id { get; set; }

        public int NumberOfDays { get; set; }

        public EmployeeVM Employee { get; set; }

        public int Period { get; set; }

        public string EmployeeId { get; set; }

        public LeaveTypeVM LeaveType { get; set; }

        public Guid LeaveTypeId { get; set; }

        public DateTime CreatedOn { get; set; }

        public DateTime UpdatedOn { get; set; }

        public IEnumerable<LeaveTypeVM> LeaveTypes { get; set; }

        public IEnumerable<EmployeeVM> Employees { get; set; }
    }
}
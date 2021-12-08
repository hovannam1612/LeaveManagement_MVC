using LeaveManagement.WebApp.Models.ViewModels.Employees;
using LeaveManagement.WebApp.Models.ViewModels.LeaveTypes;
using System;
using System.ComponentModel.DataAnnotations;

namespace LeaveManagement.WebApp.Models.ViewModels.LeaveAllocations
{
    public class UpdateLeaveAllocationVM
    {
        public Guid Id { get; set; }

        public EmployeeVM Employee { get; set; }

        public string EmployeeId { get; set; }

        [Display(Name = "Number Of Days")]
        [Range(1, 50, ErrorMessage = "Number of days must be less than 50")]
        public int NumberOfDays { get; set; }

        public LeaveTypeVM LeaveType { get; set; }
    }
}
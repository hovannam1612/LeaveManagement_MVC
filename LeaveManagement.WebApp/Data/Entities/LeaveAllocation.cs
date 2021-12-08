using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LeaveManagement.WebApp.Data.Entities
{
    public class LeaveAllocation : BaseEntity<Guid>
    {
        public int NumberOfDays { get; set; }

        [Required]
        [ForeignKey("EmployeeId")]
        public string EmployeeId { get; set; }

        public Employee Employee { get; set; }

        [ForeignKey("LeaveTypeId")]
        public Guid LeaveTypeId { get; set; }

        public LeaveType LeaveType { get; set; }

        public int Period { get; set; }
    }
}
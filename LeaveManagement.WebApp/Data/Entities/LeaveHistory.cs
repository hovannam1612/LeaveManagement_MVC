using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace LeaveManagement.WebApp.Data.Entities
{
    public class LeaveHistory : BaseEntity<Guid>
    {
        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        public DateTime DateRequested { get; set; }

        public DateTime DateActioned { get; set; }

        public bool Cancelled { get; set; }

        public bool? Approved { get; set; }

        [ForeignKey("ApprovedById")]
        public string ApprovedById { get; set; }

        public Employee ApprovedBy { get; set; }

        [ForeignKey("LeaveTypeId")]
        public Guid LeaveTypeId { get; set; }

        public LeaveType LeaveType { get; set; }

        [ForeignKey("RequestingEmployeeId")]
        public Employee RequestingEmployee { get; set; }

        public string RequestingEmployeeId { get; set; }

        public string RequestComments { get; set; }
    }
}
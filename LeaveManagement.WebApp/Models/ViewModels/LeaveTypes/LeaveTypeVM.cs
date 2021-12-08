using System;

namespace LeaveManagement.WebApp.Models.ViewModels.LeaveTypes
{
    public class LeaveTypeVM
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public int DefaultDays { get; set; }

        public DateTime CreatedOn { get; set; }

        public DateTime UpdatedOn { get; set; }
    }
}
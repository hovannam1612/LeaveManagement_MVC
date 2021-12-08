using System;
using System.ComponentModel.DataAnnotations;

namespace LeaveManagement.WebApp.Data.Entities
{
    public class LeaveType : BaseEntity<Guid>
    {
        [Required]
        public string Name { get; set; }

        public int DefaultDays { get; set; }
    }
}
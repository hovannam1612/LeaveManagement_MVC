using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace LeaveManagement.WebApp.Models.ViewModels.LeaveTypes
{
    public class CreateLeaveTypeVM
    {
        [DisplayName("Name Of Leave Type")]
        [StringLength(100, ErrorMessage = "{0} length must be between {2} and {1}.", MinimumLength = 3)]
        [Required(ErrorMessage = "{0} must be required")]
        public string Name { get; set; }

        [DisplayName("Default number of days")]
        [Required(ErrorMessage = "{0} must be required")]
        public int DefaultDays { get; set; }

        public DateTime CreatedOn { get; set; }

        public DateTime UpdatedOn { get; set; }
    }
}
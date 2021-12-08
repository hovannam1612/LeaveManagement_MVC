using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace LeaveManagement.WebApp.Models.ViewModels.LeaveHistories
{
    public class CreateLeaveRequestVM
    {
        [Display(Name = "Start Date")]
        [Required(ErrorMessage = "{0} must be required")]
        public string StartDate { get; set; }

        [Display(Name = "End Date")]
        [Required(ErrorMessage = "{0} must be required")]
        public string EndDate { get; set; }

        public IEnumerable<SelectListItem> LeaveTypes { get; set; }

        [Display(Name = "Leave Type")]
        public Guid LeaveTypeId { get; set; }

        [Display(Name = "Request Comment")]
        public string RequestComments { get; set; }
    }
}
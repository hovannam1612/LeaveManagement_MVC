using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace LeaveManagement.WebApp.Models.ViewModels.LeaveHistories
{
    public class ViewLeaveRequestVM
    {
        [Display(Name = "Number Of Requests")]
        public int TotalRequests { get; set; }

        [Display(Name = "Approved Requests")]
        public int ApprovedRequests { get; set; }

        [Display(Name = "Pending Requests")]
        public int PendingRequests { get; set; }

        [Display(Name = "Rejected Requests")]
        public int RejectedRequests { get; set; }

        public IEnumerable<LeaveRequestVM> LeaveRequests { get; set; }
    }
}
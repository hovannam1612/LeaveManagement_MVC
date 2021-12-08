using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace LeaveManagement.WebApp.Models.ViewModels.Employees
{
    public class UserVM
    {
        public string Id { get; set; }

        public string Firstname { get; set; }

        public string Lastname { get; set; }

        public string UserName { get; set; }

        public string Email { get; set; }

        [Display(Name = "Choose roles name:")]
        public string[] RoleNames { get; set; }

        public SelectList AllRoles { get; set; }
    }
}
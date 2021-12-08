using AutoMapper;
using LeaveManagement.WebApp.Data.Entities;
using LeaveManagement.WebApp.Interfaces;
using LeaveManagement.WebApp.Interfaces.IServices;
using LeaveManagement.WebApp.Models.ViewModels.LeaveAllocations;
using LeaveManagement.WebApp.Models.ViewModels.LeaveTypes;
using LeaveManagement.WebApp.Utils.Constants;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LeaveManagement.WebApp.Areas.Admin.Controllers
{
    public class LeaveAllocationsController : BaseController
    {
        private readonly UserManager<Employee> _userManager;
        private readonly ILeaveAllocationService _leaveAllocationService;
        private readonly ILeaveTypeService _leaveTypeService;
        private readonly ILogger<LeaveAllocationsController> _logger;

        public LeaveAllocationsController(
            UserManager<Employee> userManager,
            ILeaveAllocationService leaveAllocationService,
            ILeaveTypeService leaveTypeService,
            ILogger<LeaveAllocationsController> logger
            )
        {
            _userManager = userManager;
            _leaveTypeService = leaveTypeService;
            _leaveAllocationService = leaveAllocationService;
            _logger = logger;
        }

        [TempData]
        public string StatusMessage { get; set; }

        public async Task<IActionResult> Index()
        {
            var leaveTypes = await _leaveTypeService.GetAll();

            var allocationVM = new LeaveAllocationVM
            {
                LeaveTypes = leaveTypes
            };
            return View(allocationVM);
        }

        public async Task<IActionResult> SetLeaveAllocations(Guid id)
        {
            var leaveType = await _leaveTypeService.FindById(id);
            var employees = await _userManager.GetUsersInRoleAsync(UserRole.Employee);
            foreach (var emp in employees)
            {
                if (await _leaveAllocationService.CheckAllocation(id, emp.Id))
                    continue;
                var leaveAllocationVM = new CreateLeaveAllocationVM
                {
                    EmployeeId = emp.Id,
                    LeaveTypeId = id,
                    NumberOfDays = leaveType.DefaultDays,
                    Period = DateTime.Now.Year
                };

                await _leaveAllocationService.Create(leaveAllocationVM);
            }
            StatusMessage = $"Set allocation success for employee has leave type: {leaveType.Name}";
            return RedirectToAction("Index");
        }
    }
}

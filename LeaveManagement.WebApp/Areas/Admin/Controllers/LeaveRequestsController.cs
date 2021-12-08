using AutoMapper;
using LeaveManagement.WebApp.Data.Entities;
using LeaveManagement.WebApp.Interfaces;
using LeaveManagement.WebApp.Interfaces.IServices;
using LeaveManagement.WebApp.Models.ViewModels;
using LeaveManagement.WebApp.Utils.Constants;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;

namespace LeaveManagement.WebApp.Areas.Admin.Controllers
{
    public class LeaveRequestsController : BaseController
    {
        private readonly ILeaveHistoryService _leaveHistoryService;
        private readonly ILeaveAllocationService _leaveAllocationService;
        private readonly ILeaveTypeService _leaveTypeService;
        private readonly IMapper _mapper;
        private readonly UserManager<Employee> _userManager;
        private readonly ILogger<LeaveRequestsController> _logger;

        public LeaveRequestsController(
           ILeaveHistoryService leaveHistoryService,
           ILeaveTypeService leaveTypeService,
           ILeaveAllocationService leaveAllocationService,
           UserManager<Employee> userManager,
           IMapper mapper,
           ILogger<LeaveRequestsController> logger
           )
        {
            _mapper = mapper;
            _leaveAllocationService = leaveAllocationService;
            _userManager = userManager;
            _leaveTypeService = leaveTypeService;
            _leaveHistoryService = leaveHistoryService;
            _logger = logger;
        }

        [TempData]
        public string StatusMessage { get; set; }

        [Authorize(Roles = UserRole.Admin)]
        public async Task<IActionResult> Index()
        {
            var viewleaveRequest = await _leaveHistoryService.FindAll();
            return View(viewleaveRequest);
        }

        public async Task<ActionResult> Details(Guid id)
        {
            var leaveRequest = await _leaveHistoryService.FindById(id);
            var model = _mapper.Map<LeaveRequestVM>(leaveRequest);
            return View(model);
        }

        public async Task<ActionResult> ApproveRequest(Guid id)
        {
            try
            {
                var user = await _userManager.GetUserAsync(User);
                var leaveRequest = await _leaveHistoryService.FindById(id);
                var employeeid = leaveRequest.RequestingEmployeeId;
                var leaveTypeId = leaveRequest.LeaveTypeId;
                var allocation = await _leaveAllocationService.GetLeaveAllocationsByEmployeeAndType(employeeid, leaveTypeId);
                int daysRequested = (int)(leaveRequest.EndDate - leaveRequest.StartDate).TotalDays;
                allocation.NumberOfDays = allocation.NumberOfDays - daysRequested;

                leaveRequest.Approved = true;
                leaveRequest.ApprovedById = user.Id;
                leaveRequest.DateActioned = DateTime.Now;

                var isSuccess = _leaveHistoryService.Update(leaveRequest);
                if (!isSuccess)
                {
                    return View();
                }
                StatusMessage = "Approved success request";
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return View();
            }
        }

        public async Task<ActionResult> RejectRequest(Guid id)
        {
            try
            {
                var user = await _userManager.GetUserAsync(User);
                var leaveRequest = await _leaveHistoryService.FindById(id);
                leaveRequest.Approved = false;
                leaveRequest.ApprovedById = user.Id;
                leaveRequest.DateActioned = DateTime.Now;

                var isSuccess = _leaveHistoryService.Update(leaveRequest);
                if (!isSuccess)
                {
                    return View();
                }
                StatusMessage = "Reject success request";
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return View();
            }
        }
    }
}
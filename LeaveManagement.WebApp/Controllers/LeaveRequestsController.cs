using AutoMapper;
using LeaveManagement.WebApp.Data.Entities;
using LeaveManagement.WebApp.Interfaces;
using LeaveManagement.WebApp.Interfaces.IServices;
using LeaveManagement.WebApp.Models.ViewModels;
using LeaveManagement.WebApp.Models.ViewModels.LeaveAllocations;
using LeaveManagement.WebApp.Models.ViewModels.LeaveHistories;
using LeaveManagement.WebApp.Models.ViewModels.LeaveRequests;
using LeaveManagement.WebApp.Utils.Constants;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LeaveManagement.WebApp.Controllers
{
    [Authorize(Roles = UserRole.Employee)]
    public class LeaveRequestsController : Controller
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

        public async Task<ActionResult> Create()
        {
            var leaveTypes = await _leaveTypeService.GetAll();
            var leaveTypeItems = leaveTypes.Select(x => new SelectListItem
            {
                Text = x.Name,
                Value = x.Id.ToString()
            });
            var model = new CreateLeaveRequestVM
            {
                LeaveTypes = leaveTypeItems
            };
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(CreateLeaveRequestVM model)
        {
            if (!ModelState.IsValid)
            {
                var leaveTypes = await _leaveTypeService.GetAll();
                var leaveTypeItems = leaveTypes.Select(x => new SelectListItem
                {
                    Text = x.Name,
                    Value = x.Id.ToString()
                });
                model.LeaveTypes = leaveTypeItems;
                return View(model);
            }
            try
            {
                var startDate = DateTime.ParseExact(model.StartDate, "MM/dd/yyyy", null);
                var endDate = DateTime.ParseExact(model.EndDate, "MM/dd/yyyy", null);
                var leaveTypes = await _leaveTypeService.GetAll();
                var leaveTypeItems = leaveTypes.Select(x => new SelectListItem
                {
                    Text = x.Name,
                    Value = x.Id.ToString()
                });
                model.LeaveTypes = leaveTypeItems;

                if (DateTime.Compare(startDate, endDate) > 0)
                {
                    StatusMessage = "Error: Start date cannot be furthur than the end date";
                    return View(model);
                }

                if (startDate < DateTime.Now)
                {
                    StatusMessage = "Error: Start date cannot be in the past";
                    return View(model);
                }

                var employee = await _userManager.GetUserAsync(User);
                var allocation = await _leaveAllocationService.GetLeaveAllocationsByEmployeeAndType(employee.Id, model.LeaveTypeId);
                int daysRequested = (int)(endDate.Date - startDate.Date).TotalDays;

                if (daysRequested > allocation.NumberOfDays)
                {
                    StatusMessage = "Error: You do not sufficient days for this request";
                    return View(model);
                }

                var leaveRequestModel = new LeaveRequestVM
                {
                    RequestingEmployeeId = employee.Id,
                    StartDate = startDate,
                    EndDate = endDate,
                    RequestComments = model.RequestComments,
                    Approved = null,
                    DateRequested = DateTime.Now,
                    DateActioned = DateTime.Now,
                    LeaveTypeId = model.LeaveTypeId
                };

                var leaveRequest = _mapper.Map<LeaveHistory>(leaveRequestModel);
                var isSuccess = await _leaveHistoryService.Create(leaveRequest);
                if (!isSuccess)
                {
                    StatusMessage = "Error: Leave request failed";
                }

                StatusMessage = "Leave request successfully";
                return RedirectToAction("MyLeave");
            }
            catch (Exception ex)
            {
                StatusMessage = "Error: Employee has not been allocated to this leave type";
                return View(model);
            }
        }

        public async Task<ActionResult> MyLeave()
        {
            var employee = await _userManager.GetUserAsync(User);
            var employeeid = employee.Id;
            var employeeAllocations = await _leaveAllocationService.GetLeaveAllocationsByEmployee(employeeid);
            var employeeRequests = await _leaveHistoryService.GetLeaveRequestByEmployee(employeeid);

            var employeeAllocationsModel = _mapper.Map<List<LeaveAllocationVM>>(employeeAllocations);
            var employeeRequestsModel = _mapper.Map<List<LeaveRequestVM>>(employeeRequests);

            var model = new EmployeeLeaveRequestViewVM
            {
                LeaveAllocations = employeeAllocationsModel,
                LeaveRequests = employeeRequestsModel
            };

            return View(model);
        }

        public async Task<ActionResult> CancelRequestAsync(Guid id)
        {
            var leaveRequest = await _leaveHistoryService.FindById(id);
            leaveRequest.Cancelled = true;
            var isSuccess = _leaveHistoryService.Update(leaveRequest);
            if (!isSuccess)
            {
                return View();
            }
            StatusMessage = "Cancelled request successfully";
            return RedirectToAction(nameof(MyLeave));
        }
    }
}
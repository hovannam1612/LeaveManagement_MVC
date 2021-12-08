using AutoMapper;
using LeaveManagement.WebApp.Interfaces.IServices;
using LeaveManagement.WebApp.Models.ViewModels.LeaveAllocations;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;

namespace LeaveManagement.WebApp.Areas.Admin.Controllers
{
    public class EmployeesController : BaseController
    {
        private readonly IEmployeeService _employeeService;
        private readonly IMapper _mapper;
        private readonly ILeaveAllocationService _leaveAllocationService;
        private readonly ILogger<EmployeesController> _logger;

        public EmployeesController(
            IEmployeeService employeeService,
            ILeaveAllocationService leaveAllocationService,
            ILogger<EmployeesController> logger,
            IMapper mapper
           )
        {
            _mapper = mapper;
            _leaveAllocationService = leaveAllocationService;
            _employeeService = employeeService;
            _logger = logger;
        }

        public async Task<IActionResult> Index()
        {
            var employees = await _employeeService.GetAllAsync();
            return View(employees);
        }

        public async Task<IActionResult> Detail(string id)
        {
            var allocationVM = await _employeeService.Detail(id);
            return View(allocationVM);
        }

        public async Task<ActionResult> UpdateAllocation(Guid id)
        {
            var leaveAllocation = await _leaveAllocationService.FindById(id);
            var leaveAllocationEdit = _mapper.Map<UpdateLeaveAllocationVM>(leaveAllocation);
            return View(leaveAllocationEdit);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> UpdateAllocation(UpdateLeaveAllocationVM model)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    TempData["Message"] = "Update failed";
                    return View(model);
                }
                var isSuccess = await _leaveAllocationService.Update(model);
                if (isSuccess)
                {
                    TempData["Message"] = "Update successfully";
                    return RedirectToAction(nameof(Detail), new { id = model.EmployeeId });
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return View(model);
            }
            return View(model);
        }
    }
}
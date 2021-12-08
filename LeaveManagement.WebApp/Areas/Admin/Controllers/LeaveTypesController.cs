using AutoMapper;
using LeaveManagement.WebApp.Interfaces;
using LeaveManagement.WebApp.Models.ViewModels.LeaveTypes;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LeaveManagement.WebApp.Areas.Admin.Controllers
{
    public class LeaveTypesController : BaseController
    {
        private readonly ILeaveTypeService _leaveTypeService;
        private readonly ILogger<LeaveTypesController> _logger;
        private readonly IMapper _mapper;

        public LeaveTypesController(ILeaveTypeService leaveTypeService, ILogger<LeaveTypesController> logger, IMapper mapper)
        {
            _leaveTypeService = leaveTypeService;
            _logger = logger;
            _mapper = mapper;
        }

        public async Task<IActionResult> Index()
        {
            var leaveTypes = await _leaveTypeService.GetAll();
            return View(leaveTypes);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateLeaveTypeVM createLeaveType)
        {
            if (!ModelState.IsValid)
            {
                TempData["Message"] = "Create failed";
                return View(createLeaveType);
            }
            try
            {
                var isSuccess = await _leaveTypeService.Create(createLeaveType);
                if (isSuccess)
                {
                    TempData["Message"] = "Create successfully";
                    return RedirectToAction("Index", "LeaveTypes");
                }
                else
                {
                    ModelState.AddModelError("", "Name of type is existed");
                    return View(createLeaveType);
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                TempData["Message"] = "Create failed";
            }
            return View(createLeaveType);
        }

        public IActionResult Delete(Guid id)
        {
            try
            {
                var isDelete = _leaveTypeService.Delete(id);
                if (isDelete)
                    TempData["Message"] = "Delete successfully";
            }
            catch (Exception ex)
            {
                TempData["Message"] = "Delete failed";
                _logger.LogError(ex.Message);
                return RedirectToAction("Index", "LeaveTypes");
            }

            return RedirectToAction("Index", "LeaveTypes");
        }

        public async Task<IActionResult> Update(Guid id)
        {
            var leaveTypeVM = await _leaveTypeService.FindById(id);
            var leaveTypeUpdate = _mapper.Map<UpdateLeaveTypeVM>(leaveTypeVM);
            return View(leaveTypeUpdate);
        }

        [HttpPost]
        public IActionResult UpdateAsync(UpdateLeaveTypeVM updateLeaveTypeVM)
        {
            if (!ModelState.IsValid)
            {
                TempData["Message"] = "Update failed";
                return View(updateLeaveTypeVM);
            }
            try
            {
                var isSuccess = _leaveTypeService.UpdateAsync(updateLeaveTypeVM);
                if (isSuccess)
                {
                    TempData["Message"] = "Update sucessfully";
                    return RedirectToAction("Index", "LeaveTypes");
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                TempData["Message"] = "Update failed";
            }

            return View(updateLeaveTypeVM);
        }

        public async Task<IActionResult> Detail(Guid id)
        {
            var leaveTypeVM = await _leaveTypeService.FindById(id);
            return View(leaveTypeVM);
        }
    }
}

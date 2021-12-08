using AutoMapper;
using LeaveManagement.WebApp.Data.Entities;
using LeaveManagement.WebApp.Interfaces.IServices;
using LeaveManagement.WebApp.Models.ViewModels.Employees;
using LeaveManagement.WebApp.Models.ViewModels.LeaveAllocations;
using LeaveManagement.WebApp.UnitOfWorks;
using LeaveManagement.WebApp.Utils.Constants;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LeaveManagement.WebApp.Services
{
    public class EmployeeService : IEmployeeService
    {
        private readonly UserManager<Employee> _userManager;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public EmployeeService(
            UserManager<Employee> userManager,
            IUnitOfWork unitOfWork,
            IMapper mapper
            )
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _userManager = userManager;
        }

        public async Task<ViewAllocationsVM> Detail(string employeeId)
        {
            var employee = _mapper.Map<EmployeeVM>(await _userManager.FindByIdAsync(employeeId));
            var period = DateTime.Now.Year;
            var records = await _unitOfWork.LeaveAllocationRepository.FindAll(
                expression: q => q.EmployeeId == employeeId && q.Period == period,
                includes: q => q.Include(x => x.LeaveType));

            var allocations = _mapper.Map<List<LeaveAllocationVM>>
                    (records);

            var model = new ViewAllocationsVM
            {
                Employee = employee,
                LeaveAllocations = allocations
            };
            return model;
        }

        public async Task<IEnumerable<EmployeeVM>> GetAllAsync()
        {
            var employees = await _userManager.GetUsersInRoleAsync(UserRole.Employee);
            return _mapper.Map<IEnumerable<EmployeeVM>>(employees);
        }
    }
}
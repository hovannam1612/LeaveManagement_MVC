using AutoMapper;
using LeaveManagement.WebApp.Data.Entities;
using LeaveManagement.WebApp.Interfaces.IServices;
using LeaveManagement.WebApp.Models.ViewModels.LeaveAllocations;
using LeaveManagement.WebApp.UnitOfWorks;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LeaveManagement.WebApp.Services
{
    public class LeaveAllocationService : ILeaveAllocationService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public LeaveAllocationService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<bool> CheckAllocation(Guid leaveTypeId, string employeeId)
        {
            return await _unitOfWork.LeaveAllocationRepository.CheckAllocationExisted(leaveTypeId, employeeId);
        }

        public async Task<bool> Create(CreateLeaveAllocationVM createLeaveAllocationVM)
        {
            var leaveAllocation = _mapper.Map<LeaveAllocation>(createLeaveAllocationVM);
            await _unitOfWork.LeaveAllocationRepository.Create(leaveAllocation);
            return _unitOfWork.SaveChanges() > 0;
        }

        public bool Delete(Guid id)
        {
            throw new NotImplementedException();
        }

        public async Task<LeaveAllocationVM> FindById(Guid id)
        {
            var leaveallocation = await _unitOfWork.LeaveAllocationRepository.FindByConditions(q => q.Id == id,
                includes: q => q.Include(x => x.Employee).Include(x => x.LeaveType));

            return _mapper.Map<LeaveAllocationVM>(leaveallocation);
        }

        public IEnumerable<LeaveAllocationVM> GetAll()
        {
            var leaveAllocations = _unitOfWork.LeaveAllocationRepository.FindAll();
            return _mapper.Map<IEnumerable<LeaveAllocationVM>>(leaveAllocations);
        }

        public Task<ICollection<LeaveAllocation>> GetLeaveAllocationsByEmployee(string id)
        {
            return _unitOfWork.LeaveAllocationRepository.GetLeaveAllocationsByEmployee(id);
        }

        public Task<LeaveAllocation> GetLeaveAllocationsByEmployeeAndType(string employeeid, Guid leavetypeid)
        {
            return _unitOfWork.LeaveAllocationRepository.GetLeaveAllocationsByEmployeeAndType(employeeid, leavetypeid);
        }

        public async Task<bool> Update(UpdateLeaveAllocationVM updateLeaveType)
        {
            var record = await _unitOfWork.LeaveAllocationRepository.FindByConditions(q => q.Id == updateLeaveType.Id);
            record.NumberOfDays = updateLeaveType.NumberOfDays;
            _unitOfWork.LeaveAllocationRepository.Update(record);
            return _unitOfWork.SaveChanges() > 0;
        }
    }
}
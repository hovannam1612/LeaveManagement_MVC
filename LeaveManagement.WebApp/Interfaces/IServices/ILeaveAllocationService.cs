using LeaveManagement.WebApp.Data.Entities;
using LeaveManagement.WebApp.Models.ViewModels.LeaveAllocations;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LeaveManagement.WebApp.Interfaces.IServices
{
    public interface ILeaveAllocationService
    {
        IEnumerable<LeaveAllocationVM> GetAll();

        Task<bool> Create(CreateLeaveAllocationVM createLeaveAllocationVM);

        Task<bool> Update(UpdateLeaveAllocationVM updateLeaveType);

        Task<bool> CheckAllocation(Guid leaveTypeId, string employeeId);

        Task<LeaveAllocationVM> FindById(Guid id);

        Task<LeaveAllocation> GetLeaveAllocationsByEmployeeAndType(string employeeid, Guid leavetypeid);

        Task<ICollection<LeaveAllocation>> GetLeaveAllocationsByEmployee(string id);

        bool Delete(Guid id);
    }
}
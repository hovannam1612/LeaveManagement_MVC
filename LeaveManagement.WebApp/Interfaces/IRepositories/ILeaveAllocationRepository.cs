using LeaveManagement.WebApp.Data.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LeaveManagement.WebApp.Interfaces
{
    public interface ILeaveAllocationRepository : IRepositoryBase<LeaveAllocation, Guid>
    {
        Task<bool> CheckAllocationExisted(Guid leaveTypeId, string employeeId);

        Task<LeaveAllocation> GetLeaveAllocationsByEmployeeAndType(string employeeid, Guid leavetypeid);

        Task<ICollection<LeaveAllocation>> GetLeaveAllocationsByEmployee(string id);
    }
}
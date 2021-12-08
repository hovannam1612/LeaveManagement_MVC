using LeaveManagement.WebApp.Data.Entities;
using System;
using System.Collections.Generic;

namespace LeaveManagement.WebApp.Interfaces
{
    public interface ILeaveTypeRepository : IRepositoryBase<LeaveType, Guid>
    {
        ICollection<LeaveType> GetEmployeesByLeaveType(int id);
    }
}
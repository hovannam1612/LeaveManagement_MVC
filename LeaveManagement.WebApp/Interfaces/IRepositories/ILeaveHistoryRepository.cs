using LeaveManagement.WebApp.Data.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LeaveManagement.WebApp.Interfaces
{
    public interface ILeaveHistoryRepository : IRepositoryBase<LeaveHistory, Guid>
    {
        Task<ICollection<LeaveHistory>> GetLeaveRequestByEmployee(string employeeid);

        Task<LeaveHistory> FindById(Guid id);
    }
}
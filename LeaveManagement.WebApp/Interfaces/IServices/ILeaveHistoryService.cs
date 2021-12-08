using LeaveManagement.WebApp.Data.Entities;
using LeaveManagement.WebApp.Models.ViewModels.LeaveHistories;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LeaveManagement.WebApp.Interfaces
{
    public interface ILeaveHistoryService
    {
        Task<ViewLeaveRequestVM> FindAll();

        bool Update(LeaveHistory entity);

        Task<LeaveHistory> FindById(Guid id);

        Task<bool> Create(LeaveHistory leaveRequest);

        Task<ICollection<LeaveHistory>> GetLeaveRequestByEmployee(string employeeid);
    }
}
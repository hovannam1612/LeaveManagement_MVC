using LeaveManagement.WebApp.Models.ViewModels.LeaveTypes;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LeaveManagement.WebApp.Interfaces
{
    public interface ILeaveTypeService
    {
        Task<IEnumerable<LeaveTypeVM>> GetAll();

        Task<bool> Create(CreateLeaveTypeVM createLeaveType);

        bool UpdateAsync(UpdateLeaveTypeVM updateLeaveType);

        Task<LeaveTypeVM> FindById(Guid id);

        bool Delete(Guid id);
    }
}
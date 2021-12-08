using LeaveManagement.WebApp.Data;
using LeaveManagement.WebApp.Data.Entities;
using LeaveManagement.WebApp.Interfaces;
using System;
using System.Collections.Generic;

namespace LeaveManagement.WebApp.Repositories
{
    public class LeaveTypeRepository : RepositoryBase<LeaveType, Guid>, ILeaveTypeRepository
    {
        public LeaveTypeRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
        }

        public ICollection<LeaveType> GetEmployeesByLeaveType(int id)
        {
            throw new NotImplementedException();
        }
    }
}
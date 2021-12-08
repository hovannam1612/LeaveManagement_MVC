using LeaveManagement.WebApp.Data;
using LeaveManagement.WebApp.Data.Entities;
using LeaveManagement.WebApp.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LeaveManagement.WebApp.Repositories
{
    public class LeaveAllocationRepository : RepositoryBase<LeaveAllocation, Guid>, ILeaveAllocationRepository
    {
        private readonly ApplicationDbContext _db;
        public LeaveAllocationRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
            _db = dbContext;
        }

        public async Task<bool> CheckAllocationExisted(Guid leaveTypeId, string employeeId)
        {
            var period = DateTime.Now.Year;
            var allocations = await GetAll();
            return allocations.Any(x => x.EmployeeId == employeeId && x.LeaveTypeId == leaveTypeId && x.Period == period);
        }

        public async Task<ICollection<LeaveAllocation>> GetLeaveAllocationsByEmployee(string id)
        {
            var period = DateTime.Now.Year;
            var allocations = await GetAll();
            return allocations
                .Where(x => x.EmployeeId == id && x.Period == period)
                .ToList();
        }

        public async Task<ICollection<LeaveAllocation>> GetAll()
        {
            return await _db.LeaveAllocations
                .Include(x => x.LeaveType)
                .Include(x => x.Employee)
                .ToListAsync();
        }

        public async Task<LeaveAllocation> GetLeaveAllocationsByEmployeeAndType(string employeeid, Guid leavetypeid)
        {
            var period = DateTime.Now.Year;
            var allocations = await GetAll();
            return allocations
                .FirstOrDefault(x => x.EmployeeId == employeeid && x.Period == period && x.LeaveTypeId == leavetypeid);
        }
    }
}
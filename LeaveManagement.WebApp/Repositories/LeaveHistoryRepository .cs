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
    public class LeaveHistoryRepository : RepositoryBase<LeaveHistory, Guid>, ILeaveHistoryRepository
    {
        private readonly ApplicationDbContext _db;
        public LeaveHistoryRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
            _db = dbContext;
        }

        public async Task<LeaveHistory> FindById(Guid id)
        {
            return await _db.LeaveHistories
                .Include(q => q.RequestingEmployee)
                .Include(q => q.ApprovedBy)
                .Include(q => q.LeaveType)
                .FirstOrDefaultAsync(q => q.Id == id);
        }

        public async Task<ICollection<LeaveHistory>> GetAll()
        {
            return await _db.LeaveHistories
                .Include(q => q.RequestingEmployee)
                .Include(q => q.ApprovedBy)
                .Include(q => q.LeaveType)
                .ToListAsync();
        }

        public async Task<ICollection<LeaveHistory>> GetLeaveRequestByEmployee(string employeeid)
        {
            var requests = await GetAll();
            return requests
                .Where(x => x.RequestingEmployeeId == employeeid)
                .ToList();
        }
    }
}
using LeaveManagement.WebApp.Data;
using LeaveManagement.WebApp.Interfaces;
using LeaveManagement.WebApp.Repositories;

namespace LeaveManagement.WebApp.UnitOfWorks
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _dbContext;
        private ILeaveTypeRepository _leaveTypeRepository;
        private ILeaveAllocationRepository _leaveAllocationRepository;
        private ILeaveHistoryRepository _leaveHistoryRepository;

        public UnitOfWork(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public ILeaveTypeRepository LeaveTypeRepository => _leaveTypeRepository ??= new LeaveTypeRepository(_dbContext);

        public ILeaveAllocationRepository LeaveAllocationRepository => _leaveAllocationRepository ??= new LeaveAllocationRepository(_dbContext);

        public ILeaveHistoryRepository LeaveHistoryRepository => _leaveHistoryRepository ??= new LeaveHistoryRepository(_dbContext);

        public ApplicationDbContext DbContext => _dbContext;

        public void Dispose()
        {
            _dbContext.Dispose();
        }

        public int SaveChanges()
        {
            return _dbContext.SaveChanges();
        }
    }
}
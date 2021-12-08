using LeaveManagement.WebApp.Data;
using LeaveManagement.WebApp.Interfaces;
using System;

namespace LeaveManagement.WebApp.UnitOfWorks
{
    public interface IUnitOfWork : IDisposable
    {
        ILeaveTypeRepository LeaveTypeRepository { get; }

        ILeaveAllocationRepository LeaveAllocationRepository { get; }

        ILeaveHistoryRepository LeaveHistoryRepository { get; }

        ApplicationDbContext DbContext { get; }

        int SaveChanges();
    }
}
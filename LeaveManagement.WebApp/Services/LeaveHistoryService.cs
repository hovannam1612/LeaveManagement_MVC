using AutoMapper;
using LeaveManagement.WebApp.Data.Entities;
using LeaveManagement.WebApp.Interfaces;
using LeaveManagement.WebApp.Models.ViewModels;
using LeaveManagement.WebApp.Models.ViewModels.LeaveHistories;
using LeaveManagement.WebApp.UnitOfWorks;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LeaveManagement.WebApp.Services
{
    public class LeaveHistoryService : ILeaveHistoryService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public LeaveHistoryService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<bool> Create(LeaveHistory leaveRequest)
        {
            await _unitOfWork.LeaveHistoryRepository.Create(leaveRequest);
            return _unitOfWork.SaveChanges() > 0;
        }

        public async Task<ViewLeaveRequestVM> FindAll()
        {
            var leaveRequests = await _unitOfWork.LeaveHistoryRepository.FindAll(
               includes: q => q.Include(x => x.RequestingEmployee).Include(x => x.LeaveType)
           );

            var leaveRequstsModel = _mapper.Map<IEnumerable<LeaveRequestVM>>(leaveRequests);
            var model = new ViewLeaveRequestVM
            {
                TotalRequests = leaveRequstsModel.ToList().Count,
                ApprovedRequests = leaveRequstsModel.Count(q => q.Approved == true),
                PendingRequests = leaveRequstsModel.Count(q => q.Approved == null),
                RejectedRequests = leaveRequstsModel.Count(q => q.Approved == false),
                LeaveRequests = leaveRequstsModel
            };
            return model;
        }

        public Task<LeaveHistory> FindById(Guid id)
        {
            return _unitOfWork.LeaveHistoryRepository.FindById(id);
        }

        public Task<ICollection<LeaveHistory>> GetLeaveRequestByEmployee(string employeeid)
        {
            return _unitOfWork.LeaveHistoryRepository.GetLeaveRequestByEmployee(employeeid);
        }

        public bool Update(LeaveHistory entity)
        {
            _unitOfWork.LeaveHistoryRepository.Update(entity);
            return _unitOfWork.SaveChanges() > 0;
        }
    }
}
using AutoMapper;
using LeaveManagement.WebApp.Data.Entities;
using LeaveManagement.WebApp.Interfaces;
using LeaveManagement.WebApp.Models.ViewModels.LeaveTypes;
using LeaveManagement.WebApp.UnitOfWorks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LeaveManagement.WebApp.Services
{
    public class LeaveTypeService : ILeaveTypeService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public LeaveTypeService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        private async Task<bool> IsExistName(string name)
        {
            var employees = await _unitOfWork.LeaveTypeRepository.FindAll();
            var obj = employees.FirstOrDefault(x => x.Name.ToLower().Equals(name.ToLower()));
            return obj != null;
        }

        public async Task<bool> Create(CreateLeaveTypeVM createLeaveType)
        {
            if (await IsExistName(createLeaveType.Name))
                return false;

            var leaveTypeInsert = _mapper.Map<LeaveType>(createLeaveType);
            await _unitOfWork.LeaveTypeRepository.Create(leaveTypeInsert);
            return _unitOfWork.SaveChanges() > 0;
        }

        public bool Delete(Guid id)
        {
            _unitOfWork.LeaveTypeRepository.Delete(id);
            return _unitOfWork.SaveChanges() > 0;
        }

        public async Task<LeaveTypeVM> FindById(Guid id)
        {
            var leaveType = await _unitOfWork.LeaveTypeRepository.FindByConditions(x => x.Id == id);
            return _mapper.Map<LeaveTypeVM>(leaveType);
        }

        public async Task<IEnumerable<LeaveTypeVM>> GetAll()
        {
            var leaveTypes = await _unitOfWork.LeaveTypeRepository.FindAll();
            return _mapper.Map<IEnumerable<LeaveTypeVM>>(leaveTypes);
        }

        public bool UpdateAsync(UpdateLeaveTypeVM updateLeaveType)
        {
            var createdOn = updateLeaveType.CreatedOn;
            var obj = _mapper.Map<LeaveType>(updateLeaveType);
            obj.CreatedOn = createdOn;
            _unitOfWork.LeaveTypeRepository.Update(obj);
            return _unitOfWork.SaveChanges() > 0;
        }
    }
}
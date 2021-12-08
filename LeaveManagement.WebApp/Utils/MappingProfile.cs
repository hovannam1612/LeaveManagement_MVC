using AutoMapper;
using LeaveManagement.WebApp.Data.Entities;
using LeaveManagement.WebApp.Models.ViewModels;
using LeaveManagement.WebApp.Models.ViewModels.Employees;
using LeaveManagement.WebApp.Models.ViewModels.LeaveAllocations;
using LeaveManagement.WebApp.Models.ViewModels.LeaveTypes;

namespace LeaveManagement.WebApp.Utils
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Employee, EmployeeVM>().ReverseMap();

            CreateMap<LeaveType, LeaveTypeVM>().ReverseMap();
            CreateMap<LeaveType, CreateLeaveTypeVM>().ReverseMap();
            CreateMap<LeaveType, UpdateLeaveTypeVM>().ReverseMap();
            CreateMap<UpdateLeaveTypeVM, LeaveTypeVM>().ReverseMap();

            CreateMap<LeaveAllocation, CreateLeaveAllocationVM>().ReverseMap();
            CreateMap<LeaveAllocation, LeaveAllocationVM>().ReverseMap();
            CreateMap<LeaveAllocationVM, UpdateLeaveAllocationVM>().ReverseMap();

            CreateMap<Employee, EmployeeVM>().ReverseMap();
            CreateMap<LeaveHistory, LeaveRequestVM>().ReverseMap();
        }
    }
}
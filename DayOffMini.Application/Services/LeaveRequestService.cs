using AutoMapper;
using DayOffMini.Domain.DTOs;
using DayOffMini.Domain.DTOs.CreateRequests;
using DayOffMini.Domain.DTOs.UpdateRequests;
using DayOffMini.Domain.Interfaces;
using DayOffMini.Domain.Interfaces.IServices;
using DayOffMini.Domain.Models;

namespace DayOffMini.Application.Services
{
    public class LeaveRequestService : ILeaveRequestService
    {
        private readonly IGenericRepository<LeaveRequest> _genericRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public LeaveRequestService(IGenericRepository<LeaveRequest> genericRepository, IUnitOfWork unitOfWork, IMapper mapper)
        {
            _genericRepository = genericRepository;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task CreateAsync(int employeeId, CreateLeaveRequestDto dto)
        {
            int pendingLeaveRequestStatusId = 1;

            LeaveRequest leaveRequest = _mapper.Map<LeaveRequest>(dto);

            leaveRequest.LeaveRequestStatusId = pendingLeaveRequestStatusId;
            leaveRequest.EmployeeId = employeeId;

            await _genericRepository.CreateAsync(leaveRequest);
            await _unitOfWork.SaveChangesAsync();
        }

        public async Task DeleteAsync(int employeeId, int leaveRequestId)
        {
            LeaveRequest leaveRequest = await _genericRepository.GetByIdAsync(leaveRequestId)
                ?? throw new KeyNotFoundException($"Leave request with ID {leaveRequestId} not found");

            if (leaveRequest.EmployeeId != employeeId)
                throw new InvalidOperationException("Leave request does not belong to the specified employee");

            _genericRepository.Delete(leaveRequest);
            await _unitOfWork.SaveChangesAsync();
        }

        public async Task<LeaveRequestDto?> GetByIdAsync(int leaveRequestId)
        {
            LeaveRequest? leaveRequest = await _genericRepository.GetByIdAsync(leaveRequestId, b => b.Employee, b => b.LeaveType, b => b.LeaveRequestStatus);
            LeaveRequestDto leaveRequestDto = _mapper.Map<LeaveRequestDto>(leaveRequest);
            return leaveRequestDto;
        }

        public async Task<ICollection<LeaveRequestDto>> GetEmployeeLeaveRequestsAsync(int employeeId)
        {
            ICollection<LeaveRequest> leaveRequests = await _genericRepository
                           .GetAllAsync(f => f.EmployeeId == employeeId,
                           a => a.Id, true, b => b.Employee, b => b.LeaveType, b => b.LeaveRequestStatus);
            return _mapper.Map<ICollection<LeaveRequestDto>>(leaveRequests);
        }

        public async Task UpdateEmployeeLeaveRequestAsync(int employeeId, int leaveRequestId, UpdateLeaveRequestDto dto)
        {
            LeaveRequest leaveRequest = await _genericRepository.GetByIdAsync(leaveRequestId)
                      ?? throw new KeyNotFoundException($"Leave Request with ID {leaveRequestId} not found");

            if (leaveRequest.EmployeeId != employeeId)
            {
                throw new InvalidOperationException($"Leave Request with ID {leaveRequestId} does not belong to Employee with ID {employeeId}");
            }

            _mapper.Map(dto, leaveRequest);
            await _unitOfWork.SaveChangesAsync();
        }
    }
}


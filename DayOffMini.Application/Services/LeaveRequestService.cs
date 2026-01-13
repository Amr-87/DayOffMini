using AutoMapper;
using DayOffMini.Domain.DTOs;
using DayOffMini.Domain.DTOs.CreateRequests;
using DayOffMini.Domain.DTOs.UpdateRequests;
using DayOffMini.Domain.Enums;
using DayOffMini.Domain.Interfaces;
using DayOffMini.Domain.Interfaces.IRepositories;
using DayOffMini.Domain.Interfaces.IServices;
using DayOffMini.Domain.Models;

namespace DayOffMini.Application.Services
{
    public class LeaveRequestService : ILeaveRequestService
    {
        private readonly IGenericRepository<LeaveRequest> _leaveRequestGenericRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly ILeaveBalanceRepository _leaveBalanceRepository;
        private readonly ILeaveRequestRepository _leaveRequestRepository;

        public LeaveRequestService(IGenericRepository<LeaveRequest> genericRepository, IUnitOfWork unitOfWork, IMapper mapper,
            ILeaveBalanceRepository leaveBalanceRepository,
            ILeaveRequestRepository leaveRequestRepository)
        {
            _leaveRequestGenericRepository = genericRepository;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _leaveBalanceRepository = leaveBalanceRepository;
            _leaveRequestRepository = leaveRequestRepository;
        }

        public async Task CreateAsync(int employeeId, CreateLeaveRequestDto dto)
        {
            await ValidateLeaveBalanceAsync(employeeId, dto.LeaveTypeId, dto.DurationInDays);

            LeaveRequest leaveRequest = _mapper.Map<LeaveRequest>(dto);

            leaveRequest.EmployeeId = employeeId;
            leaveRequest.LeaveRequestStatusId = (int)LeaveRequestStatusEnum.Pending;

            await _leaveRequestGenericRepository.CreateAsync(leaveRequest);
            await _unitOfWork.SaveChangesAsync();
        }

        public async Task UpdateEmployeeLeaveRequestAsync(int employeeId, int leaveRequestId, UpdateLeaveRequestDto dto)
        {
            var leaveRequest = await _leaveRequestGenericRepository.GetByIdAsync(leaveRequestId) ??
                throw new KeyNotFoundException($"Leave Request with ID {leaveRequestId} not found");

            if (leaveRequest.EmployeeId != employeeId)
            {
                throw new InvalidOperationException(
                    $"Leave Request with ID {leaveRequestId} does not belong to Employee with ID {employeeId}");
            }

            await ValidateLeaveBalanceAsync(employeeId, dto.LeaveTypeId, dto.DurationInDays, leaveRequestId);

            _mapper.Map(dto, leaveRequest);
            await _unitOfWork.SaveChangesAsync();
        }

        public async Task DeleteAsync(int employeeId, int leaveRequestId)
        {
            LeaveRequest leaveRequest = await _leaveRequestGenericRepository.GetByIdAsync(leaveRequestId)
                ?? throw new KeyNotFoundException($"Leave request with ID {leaveRequestId} not found");

            if (leaveRequest.EmployeeId != employeeId)
                throw new InvalidOperationException("Leave request does not belong to the specified employee");

            _leaveRequestGenericRepository.Delete(leaveRequest);
            await _unitOfWork.SaveChangesAsync();
        }

        public async Task<LeaveRequestDto?> GetByIdAsync(int leaveRequestId)
        {
            LeaveRequest? leaveRequest = await _leaveRequestGenericRepository.GetByIdAsync(leaveRequestId, b => b.Employee, b => b.LeaveType, b => b.LeaveRequestStatus);
            LeaveRequestDto leaveRequestDto = _mapper.Map<LeaveRequestDto>(leaveRequest);
            return leaveRequestDto;
        }

        public async Task<ICollection<LeaveRequestDto>> GetEmployeeLeaveRequestsAsync(int employeeId)
        {
            ICollection<LeaveRequest> leaveRequests = await _leaveRequestGenericRepository
                           .GetAllAsync(f => f.EmployeeId == employeeId,
                           a => a.Id, true, b => b.Employee, b => b.LeaveType, b => b.LeaveRequestStatus);
            return _mapper.Map<ICollection<LeaveRequestDto>>(leaveRequests);
        }

        private async Task ValidateLeaveBalanceAsync(int employeeId, int leaveTypeId, decimal requestedDays,
            int? excludeLeaveRequestId = null)
        {
            var allowedDays = await _leaveBalanceRepository.GetFixedDaysOffBalance(employeeId, leaveTypeId);

            var takenDays = await _leaveRequestRepository.GetTotalDaysOffTaken(employeeId, leaveTypeId);

            // Exclude current request when updating
            if (excludeLeaveRequestId.HasValue)
            {
                var currentRequest = await _leaveRequestGenericRepository.GetByIdAsync(excludeLeaveRequestId.Value);

                if (currentRequest != null)
                {
                    takenDays -= currentRequest.DurationInDays;
                }
            }

            var remainingDays = allowedDays - takenDays;

            if (requestedDays > remainingDays)
            {
                throw new InvalidOperationException($"Insufficient leave balance. Remaining days: {remainingDays}");
            }
        }

    }
}


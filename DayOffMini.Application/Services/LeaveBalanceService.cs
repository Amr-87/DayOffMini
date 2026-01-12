using AutoMapper;
using DayOffMini.Domain.DTOs;
using DayOffMini.Domain.DTOs.UpdateRequests;
using DayOffMini.Domain.Interfaces;
using DayOffMini.Domain.Interfaces.IServices;
using DayOffMini.Domain.Models;

namespace DayOffMini.Application.Services
{
    public class LeaveBalanceService : ILeaveBalanceService
    {
        private readonly IGenericRepository<LeaveBalance> _genericRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public LeaveBalanceService(IGenericRepository<LeaveBalance> genericRepository, IUnitOfWork unitOfWork, IMapper mapper)
        {
            _genericRepository = genericRepository;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<ICollection<LeaveBalanceDto>> GetEmployeeLeaveBalancesAsync(int employeeId)
        {
            var leaveBalances = await _genericRepository.GetAllAsync(b => b.EmployeeId == employeeId,
                e => e.Id, true, b => b.Employee, b => b.LeaveType);
            return _mapper.Map<ICollection<LeaveBalanceDto>>(leaveBalances);
        }

        public async Task UpdateEmployeeLeaveBalanceAsync(int employeeId, int leaveBalanceId, UpdateLeaveBalanceDto dto)
        {
            var leaveBalance = await _genericRepository.GetByIdAsync(leaveBalanceId)
             ?? throw new KeyNotFoundException($"Leave Balance with ID {leaveBalanceId} not found");

            if (leaveBalance.EmployeeId != employeeId)
            {
                throw new InvalidOperationException($"Leave Balance with ID {leaveBalanceId} does not belong to Employee with ID {employeeId}");
            }

            _mapper.Map(dto, leaveBalance);
            await _unitOfWork.SaveChangesAsync();
        }
    }
}

using AutoMapper;
using DayOffMini.Domain.DTOs;
using DayOffMini.Domain.DTOs.Reports;
using DayOffMini.Domain.DTOs.UpdateRequests;
using DayOffMini.Domain.Interfaces;
using DayOffMini.Domain.Interfaces.IRepositories;
using DayOffMini.Domain.Interfaces.IServices;
using DayOffMini.Domain.Models;

namespace DayOffMini.Application.Services
{
    public class LeaveBalanceService : ILeaveBalanceService
    {
        private readonly IGenericRepository<LeaveBalance> _genericRepository;
        private readonly ILeaveBalanceRepository _leaveBalanceRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public LeaveBalanceService(IGenericRepository<LeaveBalance> genericRepository, ILeaveBalanceRepository leaveBalanceRepository, IUnitOfWork unitOfWork, IMapper mapper)
        {
            _genericRepository = genericRepository;
            _leaveBalanceRepository = leaveBalanceRepository;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<ICollection<LeaveBalanceDto>> GetEmployeeLeaveBalancesAsync(int employeeId)
        {
            ICollection<LeaveBalance> leaveBalances = await _genericRepository.GetAllAsync(b => b.EmployeeId == employeeId,
                e => e.Id, true, b => b.Employee, b => b.LeaveType);
            return _mapper.Map<ICollection<LeaveBalanceDto>>(leaveBalances);
        }

        public async Task UpdateEmployeeLeaveBalanceAsync(int employeeId, int leaveBalanceId, UpdateLeaveBalanceDto dto)
        {
            LeaveBalance leaveBalance = await _genericRepository.GetByIdAsync(leaveBalanceId)
             ?? throw new KeyNotFoundException($"Leave Balance with ID {leaveBalanceId} not found");

            if (leaveBalance.EmployeeId != employeeId)
            {
                throw new InvalidOperationException($"Leave Balance with ID {leaveBalanceId} does not belong to Employee with ID {employeeId}");
            }

            _mapper.Map(dto, leaveBalance);
            await _unitOfWork.SaveChangesAsync();
        }


        public async Task<ICollection<LeaveBalancesReportDto>> GetLeaveBalancesReportAsync()
        {
            // Get raw data from repository
            ICollection<LeaveBalanceRawDto> rawData = await _leaveBalanceRepository.GetLeaveBalancesRawDataAsync();

            // Transform and aggregate data (business logic)
            ICollection<LeaveBalancesReportDto> report = rawData
                .GroupBy(x => new { x.EmployeeId, x.EmployeeName })
                .Select(empGroup => new LeaveBalancesReportDto
                {
                    EmployeeId = empGroup.Key.EmployeeId,
                    EmployeeName = empGroup.Key.EmployeeName,
                    LeaveBalances = empGroup.Select(x => new LeaveBalanceRowDto
                    {
                        LeaveTypeId = x.LeaveTypeId,
                        LeaveTypeName = x.LeaveTypeName,
                        FixedDaysOffBalance = x.FixedDaysOffBalance,
                        DaysTaken = x.DaysTaken,
                        DaysOffRemaining = x.FixedDaysOffBalance - x.DaysTaken
                    }).OrderBy(x => x.LeaveTypeId).ToList(),
                    TotalDaysOffBalance = empGroup.Sum(x => x.FixedDaysOffBalance),
                    TotalDaysOffRemaining = empGroup.Sum(x => x.FixedDaysOffBalance - x.DaysTaken)
                })
                .ToList();

            return report;
        }
    }
}

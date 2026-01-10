using AutoMapper;
using DayOffMini.Domain.DTOs;
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
        public async Task CreateAsync(LeaveBalanceDto dto)
        {
            var leaveBalance = _mapper.Map<LeaveBalance>(dto);
            await _genericRepository.CreateAsync(leaveBalance);
            await _unitOfWork.SaveChangesAsync();
        }

        public async Task DeleteAsync(int leaveBalanceId)
        {
            var leaveBalance = await _genericRepository.GetByIdAsync(leaveBalanceId);
            if (leaveBalance == null)
                throw new KeyNotFoundException();


            _genericRepository.DeleteAsync(leaveBalance);
            await _unitOfWork.SaveChangesAsync();
        }

        public async Task<ICollection<LeaveBalanceDto>> GetAllAsync()
        {
            var leaveBalances = await _genericRepository.GetAllAsync(null, e => e.Id, true, b => b.Employee, b => b.LeaveType);
            return _mapper.Map<ICollection<LeaveBalanceDto>>(leaveBalances);
        }

        public async Task<LeaveBalanceDto?> GetByIdAsync(int employeeId)
        {
            var leaveBalance = await _genericRepository.GetByIdAsync(employeeId, b => b.Employee, b => b.LeaveType);
            if (leaveBalance == null)
                throw new KeyNotFoundException();

            var dto = _mapper.Map<LeaveBalanceDto>(leaveBalance);
            return dto;
        }

        public async Task UpdateAsync(LeaveBalanceDto dto)
        {
            var leaveBalance = await _genericRepository.GetByIdAsync(dto.Id);
            if (leaveBalance == null)
                throw new KeyNotFoundException();

            var updatedLeaveBalance = _mapper.Map(dto, leaveBalance);
            _genericRepository.UpdateAsync(updatedLeaveBalance);
            await _unitOfWork.SaveChangesAsync();
        }
    }
}

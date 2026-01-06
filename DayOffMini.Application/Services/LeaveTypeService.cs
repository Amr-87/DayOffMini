using AutoMapper;
using DayOffMini.Domain.DTOs;
using DayOffMini.Domain.Interfaces;
using DayOffMini.Domain.Interfaces.IRepositories;
using DayOffMini.Domain.Interfaces.IServices;
using DayOffMini.Domain.Models;

namespace DayOffMini.Application.Services
{
    public class LeaveTypeService : ILeaveTypeService
    {
        private readonly ILeaveTypeRepository _leaveTypeRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public LeaveTypeService(ILeaveTypeRepository leaveTypeRepository, IUnitOfWork unitOfWork, IMapper mapper)
        {
            _leaveTypeRepository = leaveTypeRepository;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task CreateAsync(LeaveTypeDto leaveTypeDto)
        {
            var leaveType = _mapper.Map<LeaveType>(leaveTypeDto);
            await _leaveTypeRepository.CreateAsync(leaveType);
            await _unitOfWork.SaveChangesAsync();
        }

        public async Task DeleteAsync(int leaveTypeId)
        {
            await _leaveTypeRepository.DeleteAsync(leaveTypeId);
            await _unitOfWork.SaveChangesAsync();
        }

        public async Task<ICollection<LeaveTypeDto>> GetAllAsync()
        {
            var leaveTypes = await _leaveTypeRepository.GetAllAsync();
            return _mapper.Map<ICollection<LeaveTypeDto>>(leaveTypes);
        }

        public async Task<LeaveTypeDto?> GetByIdAsync(int leaveTypeId)
        {
            var leaveType = await _leaveTypeRepository.GetByIdAsync(leaveTypeId);
            if (leaveType == null)
                return null;
            var leaveTypeDto = _mapper.Map<LeaveTypeDto>(leaveType);
            return leaveTypeDto;
        }

        public async Task UpdateAsync(LeaveTypeDto leaveTypeDto)
        {
            var leaveType = _mapper.Map<LeaveType>(leaveTypeDto);
            await _leaveTypeRepository.UpdateAsync(leaveType);
            await _unitOfWork.SaveChangesAsync();
        }
    }
}

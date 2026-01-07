using AutoMapper;
using DayOffMini.Domain.DTOs;
using DayOffMini.Domain.Interfaces;
using DayOffMini.Domain.Interfaces.IServices;
using DayOffMini.Domain.Models;

namespace DayOffMini.Application.Services
{
    public class LeaveTypeService : ILeaveTypeService
    {
        private readonly IGenericRepository<LeaveType> _genericRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public LeaveTypeService(IGenericRepository<LeaveType> genericRepository, IUnitOfWork unitOfWork, IMapper mapper)
        {
            _genericRepository = genericRepository;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task CreateAsync(LeaveTypeDto leaveTypeDto)
        {
            var leaveType = _mapper.Map<LeaveType>(leaveTypeDto);
            await _genericRepository.CreateAsync(leaveType);
            await _unitOfWork.SaveChangesAsync();
        }

        public async Task DeleteAsync(int leaveTypeId)
        {
            var leaveType = await _genericRepository.GetByIdAsync(leaveTypeId);
            if (leaveType == null)
                throw new KeyNotFoundException();


            _genericRepository.DeleteAsync(leaveType);
            await _unitOfWork.SaveChangesAsync();
        }

        public async Task<ICollection<LeaveTypeDto>> GetAllAsync()
        {
            var leaveTypes = await _genericRepository.GetAllAsync();
            return _mapper.Map<ICollection<LeaveTypeDto>>(leaveTypes);
        }

        public async Task<LeaveTypeDto?> GetByIdAsync(int leaveTypeId)
        {
            var leaveType = await _genericRepository.GetByIdAsync(leaveTypeId);
            if (leaveType == null)
                return null;
            var leaveTypeDto = _mapper.Map<LeaveTypeDto>(leaveType);
            return leaveTypeDto;
        }

        public async Task UpdateAsync(LeaveTypeDto leaveTypeDto)
        {
            var leaveType = await _genericRepository.GetByIdAsync(leaveTypeDto.Id);
            if (leaveType == null)
                throw new KeyNotFoundException();

            var updatedLeaveType = _mapper.Map(leaveTypeDto, leaveType);
            _genericRepository.UpdateAsync(updatedLeaveType);
            await _unitOfWork.SaveChangesAsync();
        }
    }
}

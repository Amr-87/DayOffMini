using AutoMapper;
using DayOffMini.Domain.DTOs;
using DayOffMini.Domain.DTOs.UpdateRequests;
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
            LeaveType leaveType = _mapper.Map<LeaveType>(leaveTypeDto);
            await _genericRepository.CreateAsync(leaveType);
            await _unitOfWork.SaveChangesAsync();
        }

        public async Task<ICollection<LeaveTypeDto>> GetAllAsync()
        {
            ICollection<LeaveType> leaveTypes = await _genericRepository.GetAllAsync();
            return _mapper.Map<ICollection<LeaveTypeDto>>(leaveTypes);
        }

        public async Task<LeaveTypeDto?> GetByIdAsync(int leaveTypeId)
        {
            LeaveType? leaveType = await _genericRepository.GetByIdAsync(leaveTypeId);
            LeaveTypeDto leaveTypeDto = _mapper.Map<LeaveTypeDto>(leaveType);
            return leaveTypeDto;
        }

        public async Task UpdateAsync(int id, UpdateLeaveTypeDto leaveTypeDto)
        {
            LeaveType leaveType = await _genericRepository.GetByIdAsync(id)
             ?? throw new KeyNotFoundException($"Leave Type with ID {id} not found");

            _mapper.Map(leaveTypeDto, leaveType);
            await _unitOfWork.SaveChangesAsync();
        }
    }
}

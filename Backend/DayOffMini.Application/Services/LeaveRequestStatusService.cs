using AutoMapper;
using DayOffMini.Domain.DTOs;
using DayOffMini.Domain.Interfaces;
using DayOffMini.Domain.Interfaces.IServices;
using DayOffMini.Domain.Models;

namespace DayOffMini.Application.Services
{
    public class LeaveRequestStatusService : ILeaveRequestStatusService
    {
        private readonly IGenericRepository<LeaveRequestStatus> _genericRepository;
        private readonly IMapper _mapper;

        public LeaveRequestStatusService(IGenericRepository<LeaveRequestStatus> genericRepository, IMapper mapper)
        {
            _genericRepository = genericRepository;
            _mapper = mapper;
        }

        public async Task<ICollection<LeaveRequestStatusDto>> GetAllAsync()
        {
            ICollection<LeaveRequestStatus> leaveRequestStatuses = await _genericRepository.GetAllAsync();
            return _mapper.Map<ICollection<LeaveRequestStatusDto>>(leaveRequestStatuses);
        }

        public async Task<LeaveRequestStatusDto?> GetByIdAsync(int id)
        {
            LeaveRequestStatus? leaveRequestStatus = await _genericRepository.GetByIdAsync(id);
            LeaveRequestStatusDto dto = _mapper.Map<LeaveRequestStatusDto>(leaveRequestStatus);
            return dto;
        }
    }
}

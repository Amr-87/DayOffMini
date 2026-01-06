using AutoMapper;
using DayOffMini.Domain.DTOs;
using DayOffMini.Domain.Interfaces;
using DayOffMini.Domain.Interfaces.IRepositories;
using DayOffMini.Domain.Interfaces.IServices;
using DayOffMini.Domain.Models;

namespace DayOffMini.Application.Services
{
    public class LeaveRequestStatusService : ILeaveRequestStatusService
    {
        private readonly ILeaveRequestStatusRepository _leaveRequestStatusRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public LeaveRequestStatusService(ILeaveRequestStatusRepository leaveRequestStatusRepository, IUnitOfWork unitOfWork, IMapper mapper)
        {
            _leaveRequestStatusRepository = leaveRequestStatusRepository;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task CreateAsync(LeaveRequestStatusDto dto)
        {
            var leaveRequestStatus = _mapper.Map<LeaveRequestStatus>(dto);
            await _leaveRequestStatusRepository.CreateAsync(leaveRequestStatus);
            await _unitOfWork.SaveChangesAsync();
        }

        public async Task DeleteAsync(int leaveRequestStatusId)
        {
            await _leaveRequestStatusRepository.DeleteAsync(leaveRequestStatusId);
            await _unitOfWork.SaveChangesAsync();
        }

        public async Task<ICollection<LeaveRequestStatusDto>> GetAllAsync()
        {
            var leaveRequestStatuses = await _leaveRequestStatusRepository.GetAllAsync();
            return _mapper.Map<ICollection<LeaveRequestStatusDto>>(leaveRequestStatuses);
        }

        public async Task<LeaveRequestStatusDto?> GetByIdAsync(int id)
        {
            var leaveRequestStatus = await _leaveRequestStatusRepository.GetByIdAsync(id);
            if (leaveRequestStatus == null)
                return null;
            var dto = _mapper.Map<LeaveRequestStatusDto>(leaveRequestStatus);
            return dto;
        }

        public async Task UpdateAsync(LeaveRequestStatusDto dto)
        {
            var leaveRequestStatus = _mapper.Map<LeaveRequestStatus>(dto);
            await _leaveRequestStatusRepository.UpdateAsync(leaveRequestStatus);
            await _unitOfWork.SaveChangesAsync();
        }
    }
}

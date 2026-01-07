using AutoMapper;
using DayOffMini.Domain.DTOs;
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
        public async Task CreateAsync(CreateLeaveRequestDto dto)
        {
            int pendingLeaveRequestStatusId = 1;

            var leaveRequest = _mapper.Map<LeaveRequest>(dto);

            leaveRequest.LeaveRequestStatusId = pendingLeaveRequestStatusId;

            await _genericRepository.CreateAsync(leaveRequest);
            await _unitOfWork.SaveChangesAsync();
        }

        public async Task DeleteAsync(int leaveRequestId)
        {
            var leaveRequest = await _genericRepository.GetByIdAsync(leaveRequestId);
            if (leaveRequest == null)
                throw new KeyNotFoundException();


            _genericRepository.DeleteAsync(leaveRequest);
            await _unitOfWork.SaveChangesAsync();
        }

        public async Task<ICollection<LeaveRequestDto>> GetAllAsync()
        {
            var leaveRequests = await _genericRepository.GetAllAsync();
            return _mapper.Map<ICollection<LeaveRequestDto>>(leaveRequests);
        }

        public async Task<LeaveRequestDto?> GetByIdAsync(int leaveRequestId)
        {
            var leaveRequest = await _genericRepository.GetByIdAsync(leaveRequestId);
            if (leaveRequest == null)
                return null;
            var leaveRequestDto = _mapper.Map<LeaveRequestDto>(leaveRequest);
            return leaveRequestDto;
        }

        public async Task UpdateAsync(LeaveRequestDto dto)
        {
            var leaveRequest = await _genericRepository.GetByIdAsync(dto.Id);
            if (leaveRequest == null)
                throw new KeyNotFoundException();

            var updatedLeaveRequest = _mapper.Map(dto, leaveRequest);
            _genericRepository.UpdateAsync(updatedLeaveRequest);
            await _unitOfWork.SaveChangesAsync();
        }
    }
}

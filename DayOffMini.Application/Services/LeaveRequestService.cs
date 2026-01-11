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

        public async Task DeleteAsync(LeaveRequestDto dto)
        {
            var leaveRequest = _mapper.Map<LeaveRequest>(dto);
            _genericRepository.Delete(leaveRequest);
            await _unitOfWork.SaveChangesAsync();
        }

        public async Task<ICollection<LeaveRequestDto>> GetAllAsync()
        {
            var leaveRequests = await _genericRepository
                .GetAllAsync(null, a => a.Id, true, b => b.Employee, b => b.LeaveType, b => b.LeaveRequestStatus);
            return _mapper.Map<ICollection<LeaveRequestDto>>(leaveRequests);
        }

        public async Task<LeaveRequestDto?> GetByIdAsync(int leaveRequestId)
        {
            var leaveRequest = await _genericRepository.GetByIdAsync(leaveRequestId, b => b.Employee, b => b.LeaveType, b => b.LeaveRequestStatus);
            var leaveRequestDto = _mapper.Map<LeaveRequestDto>(leaveRequest);
            return leaveRequestDto;
        }

        public async Task UpdateAsync(LeaveRequestDto dto)
        {
            var updatedLeaveRequest = _mapper.Map<LeaveRequest>(dto);
            _genericRepository.Update(updatedLeaveRequest);
            await _unitOfWork.SaveChangesAsync();
        }
    }
}

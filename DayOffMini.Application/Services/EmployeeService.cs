using AutoMapper;
using DayOffMini.Application.Policies.Interfaces;
using DayOffMini.Domain.DTOs;
using DayOffMini.Domain.Interfaces;
using DayOffMini.Domain.Interfaces.IServices;
using DayOffMini.Domain.Models;

namespace DayOffMini.Application.Services
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IGenericRepository<Employee> _genericRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly ILeaveBalanceService _leaveBalanceService;
        private readonly IEmployeeLeavePolicy _employeeLeavePolicy;

        public EmployeeService(IGenericRepository<Employee> genericRepository, IUnitOfWork unitOfWork, IMapper mapper,
            ILeaveBalanceService leaveBalanceService, IEmployeeLeavePolicy employeeLeavePolicy)
        {
            _genericRepository = genericRepository;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _leaveBalanceService = leaveBalanceService;
            _employeeLeavePolicy = employeeLeavePolicy;
        }
        public async Task CreateAsync(EmployeeDto employeeDto)
        {
            var employee = _mapper.Map<Employee>(employeeDto);
            await _genericRepository.CreateAsync(employee);
            await _unitOfWork.SaveChangesAsync();

            var leaveBalances = _employeeLeavePolicy.CreateInitialLeaveBalances(employee.Id);

            foreach (var leaveBalanceDto in leaveBalances)
            {
                await _leaveBalanceService.CreateAsync(leaveBalanceDto);
            }

            await _unitOfWork.SaveChangesAsync();
        }

        public async Task UpdateAsync(EmployeeDto employeeDto)
        {
            var employee = await _genericRepository.GetByIdAsync(employeeDto.Id);
            if (employee == null)
                throw new KeyNotFoundException();

            var updatedEmployee = _mapper.Map(employeeDto, employee);
            _genericRepository.UpdateAsync(updatedEmployee);
            await _unitOfWork.SaveChangesAsync();
        }

        async Task<EmployeeDto?> IEmployeeService.GetByIdAsync(int entityId)
        {
            var employee = await _genericRepository.GetByIdAsync(entityId);
            if (employee == null)
                throw new KeyNotFoundException();

            var employeeDto = _mapper.Map<EmployeeDto>(employee);
            return employeeDto;
        }

        public async Task<ICollection<EmployeeDto>> GetAllAsync()
        {
            var employees = await _genericRepository.GetAllAsync();
            return _mapper.Map<ICollection<EmployeeDto>>(employees);
        }

        public async Task DeleteAsync(int employeeId)
        {
            var employee = await _genericRepository.GetByIdAsync(employeeId);
            if (employee == null)
                throw new KeyNotFoundException();


            _genericRepository.DeleteAsync(employee);
            await _unitOfWork.SaveChangesAsync();
        }
    }
}

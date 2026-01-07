using AutoMapper;
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
        private readonly IGenericRepository<LeaveType> _leaveTypesGenericRepository;
        private readonly IGenericRepository<LeaveBalance> _leaveBalanceGenericRepository;

        public EmployeeService(IGenericRepository<Employee> genericRepository, IUnitOfWork unitOfWork, IMapper mapper,
            IGenericRepository<LeaveType> leaveTypesGenericRepository,
            IGenericRepository<LeaveBalance> leaveBalanceGenericRepository)
        {
            _genericRepository = genericRepository;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _leaveTypesGenericRepository = leaveTypesGenericRepository;
            _leaveBalanceGenericRepository = leaveBalanceGenericRepository;
        }
        public async Task CreateAsync(EmployeeDto employeeDto)
        {
            var employee = _mapper.Map<Employee>(employeeDto);
            await _genericRepository.CreateAsync(employee);
            await _unitOfWork.SaveChangesAsync();

            var leaveTypes = await _leaveTypesGenericRepository.GetAllAsync(filter: l => l.IsDefault == true);

            foreach (var leaveType in leaveTypes)
            {
                var leaveBalance = new LeaveBalance
                {
                    EmployeeId = employee.Id,
                    LeaveTypeId = leaveType.Id,
                    DaysOffRemaining = leaveType.DaysOffBalance!.Value
                };
                await _leaveBalanceGenericRepository.CreateAsync(leaveBalance);
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

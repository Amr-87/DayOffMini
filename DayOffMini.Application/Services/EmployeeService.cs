using AutoMapper;
using DayOffMini.Domain.DTOs;
using DayOffMini.Domain.DTOs.CreateRequests;
using DayOffMini.Domain.DTOs.UpdateRequests;
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
        public async Task CreateAsync(CreateEmployeeDto dto)
        {
            Employee employee = _mapper.Map<Employee>(dto);
            await _genericRepository.CreateAsync(employee);

            #region Create Leave Balanaces
            ICollection<LeaveType> leaveTypes = await _leaveTypesGenericRepository
                   .GetAllAsync(l => l.IsDefault);

            foreach (LeaveType leaveType in leaveTypes)
            {
                LeaveBalance leaveBalance = new LeaveBalance
                {
                    Employee = employee, // let EF handle FK
                    LeaveTypeId = leaveType.Id,
                    //DaysOffRemaining = leaveType.DaysOffBalance!.Value
                };

                await _leaveBalanceGenericRepository.CreateAsync(leaveBalance);
            }
            #endregion

            await _unitOfWork.SaveChangesAsync();
        }

        public async Task UpdateAsync(int id, UpdateEmployeeDto dto)
        {
            Employee employee = await _genericRepository.GetByIdAsync(id)
                ?? throw new KeyNotFoundException($"Employee with ID {id} not found");

            _mapper.Map(dto, employee);
            await _unitOfWork.SaveChangesAsync();
        }


        async Task<EmployeeDto?> IEmployeeService.GetByIdAsync(int entityId)
        {
            Employee? employee = await _genericRepository.GetByIdAsync(entityId);
            EmployeeDto employeeDto = _mapper.Map<EmployeeDto>(employee);
            return employeeDto;
        }

        public async Task<ICollection<EmployeeDto>> GetAllAsync()
        {
            ICollection<Employee> employees = await _genericRepository.GetAllAsync();
            return _mapper.Map<ICollection<EmployeeDto>>(employees);
        }

        public async Task DeleteAsync(int id)
        {
            Employee employee = await _genericRepository.GetByIdAsync(id)
                ?? throw new KeyNotFoundException($"Employee with ID {id} not found");

            _genericRepository.Delete(employee);
            await _unitOfWork.SaveChangesAsync();
        }
    }
}

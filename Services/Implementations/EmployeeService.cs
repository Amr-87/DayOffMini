using DayOffMini.Controllers.DTOs;
using DayOffMini.Controllers.Mapping.Interfaces;
using DayOffMini.Repositories.Interfaces;
using DayOffMini.Services.Interfaces;
using DayOffMini.UnitOfWork;

namespace DayOffMini.Services.Implementations
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IEmployeeRepository _employeeRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IEmployeeMapper _mapper;

        public EmployeeService(IEmployeeRepository employeeRepository, IUnitOfWork unitOfWork, IEmployeeMapper mapper)
        {
            _employeeRepository = employeeRepository;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task CreateAsync(EmployeeDto employeeDto)
        {
            var employee = _mapper.ToEntity(employeeDto);
            await _employeeRepository.CreateAsync(employee);
            await _unitOfWork.SaveChangesAsync();
        }

        public async Task UpdateAsync(EmployeeDto employeeDto)
        {
            var employee = _mapper.ToEntity(employeeDto);
            await _employeeRepository.UpdateAsync(employee);
            await _unitOfWork.SaveChangesAsync();
        }

        async Task<EmployeeDto?> IEmployeeService.GetByIdAsync(int entityId)
        {
            var employee = await _employeeRepository.GetByIdAsync(entityId);
            if (employee == null)
                return null;
            var employeeDto = _mapper.ToDto(employee);
            return employeeDto;
        }

        public async Task<ICollection<EmployeeDto>> GetAllAsync()
        {
            var employees = await _employeeRepository.GetAllAsync();
            return employees
                .Select(employee => _mapper.ToDto(employee))
                .ToList();
        }

        public async Task DeleteAsync(int employeeId)
        {
            await _employeeRepository.DeleteAsync(employeeId);
            await _unitOfWork.SaveChangesAsync();
        }
    }
}

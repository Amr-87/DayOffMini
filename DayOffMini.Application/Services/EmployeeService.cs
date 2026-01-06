using AutoMapper;
using DayOffMini.Domain.DTOs;
using DayOffMini.Domain.Interfaces;
using DayOffMini.Domain.Interfaces.IRepositories;
using DayOffMini.Domain.Interfaces.IServices;
using DayOffMini.Domain.Models;

namespace DayOffMini.Application.Services
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IEmployeeRepository _employeeRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public EmployeeService(IEmployeeRepository employeeRepository, IUnitOfWork unitOfWork, IMapper mapper)
        {
            _employeeRepository = employeeRepository;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task CreateAsync(EmployeeDto employeeDto)
        {
            var employee = _mapper.Map<Employee>(employeeDto);
            await _employeeRepository.CreateAsync(employee);
            await _unitOfWork.SaveChangesAsync();
        }

        public async Task UpdateAsync(EmployeeDto employeeDto)
        {
            var employee = _mapper.Map<Employee>(employeeDto);
            await _employeeRepository.UpdateAsync(employee);
            await _unitOfWork.SaveChangesAsync();
        }

        async Task<EmployeeDto?> IEmployeeService.GetByIdAsync(int entityId)
        {
            var employee = await _employeeRepository.GetByIdAsync(entityId);
            if (employee == null)
                return null;
            var employeeDto = _mapper.Map<EmployeeDto>(employee);
            return employeeDto;
        }

        public async Task<ICollection<EmployeeDto>> GetAllAsync()
        {
            var employees = await _employeeRepository.GetAllAsync();
            return _mapper.Map<ICollection<EmployeeDto>>(employees);
        }

        public async Task DeleteAsync(int employeeId)
        {
            await _employeeRepository.DeleteAsync(employeeId);
            await _unitOfWork.SaveChangesAsync();
        }
    }
}

using DayOffMini.Controllers.DTOs;
using DayOffMini.Controllers.MappingExtensions;
using DayOffMini.Services.Interfaces;
using DayOffMini.UnitOfWork;

namespace DayOffMini.Services.Implementations
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IUnitOfWork _unitOfWork;

        public EmployeeService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task CreateAsync(EmployeeDto dto)
        {
            var employee = dto.ToEntity();
            await _unitOfWork.Employees.CreateAsync(employee);
            await SaveChangesAsync();
        }

        public async Task UpdateAsync(EmployeeDto entity)
        {
            await _unitOfWork.Employees.UpdateAsync(entity.ToEntity());
            await SaveChangesAsync();
        }

        async Task<EmployeeDto?> IEmployeeService.GetByIdAsync(int entityId)
        {
            var employee = await _unitOfWork.Employees.GetByIdAsync(entityId);
            return employee!.ToDto();
        }

        public async Task<ICollection<EmployeeDto>> GetAllAsync()
        {
            var employees = await _unitOfWork.Employees.GetAllAsync();
            return employees.Select(e => e.ToDto()).ToList();
        }

        public async Task DeleteAsync(int employeeId)
        {
            await _unitOfWork.Employees.DeleteAsync(employeeId);
            await SaveChangesAsync();
        }

        public async Task SaveChangesAsync()
        {
            await _unitOfWork.SaveChangesAsync();
        }
    }
}

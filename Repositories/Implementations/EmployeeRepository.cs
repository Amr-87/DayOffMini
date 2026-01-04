using DayOffMini.Data.DbContext;
using DayOffMini.Data.Models;
using DayOffMini.Repositories.Generic;
using DayOffMini.Repositories.Interfaces;

namespace DayOffMini.Repositories.Implementations
{
    public class EmployeeRepository : GenericRepository<Employee>, IEmployeeRepository
    {
        private readonly AppDbContext _dbContext;

        public EmployeeRepository(AppDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task UpdateAsync(Employee employee)
        {
            var existingEmployee = await _dbContext.Employees.FindAsync(employee.Id);
            if (existingEmployee == null)
                throw new KeyNotFoundException();

            existingEmployee.Name = employee.Name;
            existingEmployee.Email = employee.Email;
            existingEmployee.Password = employee.Password;

            _dbContext.Employees.Update(existingEmployee);
        }
    }
}

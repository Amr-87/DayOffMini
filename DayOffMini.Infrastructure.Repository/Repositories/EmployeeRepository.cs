using DayOffMini.Domain.Interfaces.IRepositories;
using DayOffMini.Domain.Models;
using DayOffMini.Infrastructure.DbContext;
using Microsoft.EntityFrameworkCore;

namespace DayOffMini.Infrastructure.Repository.Repositories
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly AppDbContext _db;

        public EmployeeRepository(AppDbContext db)
        {
            _db = db;
        }
        public async Task<Employee?> GetEmployeeByEmailAsync(string email)
        {
            return await _db.Employees.FirstOrDefaultAsync(e => e.Email == email);
        }
    }
}

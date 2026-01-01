using DayOffMini.Data.Models;

namespace DayOffMini.Repositories.Interfaces
{
    public interface IRoleRepository
    {
        bool CreateRole(Role role);
        bool UpdateRole(Role role);
        bool DeleteRole(int roleId);
        Role? GetRoleById(int roleId);
        ICollection<Role> GetAllRoles();
    }
}

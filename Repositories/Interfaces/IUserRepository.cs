using DayOffMini.Data.Models;

namespace DayOffMini.Repositories.Interfaces
{
    public interface IUserRepository
    {
        bool CreateUser(User user);
        bool UpdateUser(User user);
        bool DeleteUser(int userId);
        User? GetUserById(int userId);

    }
}

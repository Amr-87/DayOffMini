using DayOffMini.Domain.DTOs;

namespace DayOffMini.Domain.Interfaces.IServices
{
    public interface IAuthService
    {
        Task<string?> LoginAsync(string email, string password);
        Task<UserDTO?> GetUserById(int userId);
    }
}

namespace DayOffMini.Domain.Interfaces.IServices
{
    public interface IAuthService
    {
        Task<string?> LoginAsync(string email, string password);
    }
}

namespace DayOffMini.Domain.Interfaces.IRepositories
{
    public interface IUserRepo
    {
        Task<User?> GetUserByEmailAsync(string email);
    }
}

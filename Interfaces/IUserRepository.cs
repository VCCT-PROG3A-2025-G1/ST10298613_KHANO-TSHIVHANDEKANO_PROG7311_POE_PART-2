using PROG7311_POE_PART_2.Models;

namespace PROG7311_POE_PART_2.Interfaces
{
    public interface IUserRepository
    {
        Task<User?> GetByUsernameAsync(string username);
        Task<User?> GetByIdAsync(int id);
        Task AddAsync(User user);
        Task SaveAsync();
    }
}

using Microsoft.EntityFrameworkCore;
using PROG7311_POE_PART_2.Data;
using PROG7311_POE_PART_2.Interfaces;
using PROG7311_POE_PART_2.Models;

namespace PROG7311_POE_PART_2.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly AppDbContext _context;
        public UserRepository(AppDbContext context) => _context = context;

        public async Task<User?> GetByUsernameAsync(string username) =>
            await _context.Users.Include(u => u.Farmer).FirstOrDefaultAsync(u => u.Username == username);

        public async Task<User?> GetByIdAsync(int id) =>
            await _context.Users.FindAsync(id);

        public async Task AddAsync(User user) => await _context.Users.AddAsync(user);

        public async Task SaveAsync() => await _context.SaveChangesAsync();
    }
}

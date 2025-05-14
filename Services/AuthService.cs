using PROG7311_POE_PART_2.Interfaces;
using PROG7311_POE_PART_2.Models;

namespace PROG7311_POE_PART_2.Services
{
    public class AuthService
    {
        private readonly IUserRepository _userRepository;

        public AuthService(IUserRepository userRepository)
            => _userRepository = userRepository;

        // Verifies plain-text password
        public async Task<User?> LoginAsync(string username, string password)
        {
            var user = await _userRepository.GetByUsernameAsync(username);
            if (user == null) return null;

            return user.Password == password ? user : null;
        }

        // Registers a new user with plain-text password (testing only)
        public async Task<bool> RegisterAsync(string username, string password, string role)
        {
            if (await _userRepository.GetByUsernameAsync(username) != null)
                return false;

            var newUser = new User
            {
                Username = username,
                Password = password,
                Role = role
            };

            await _userRepository.AddAsync(newUser);
            await _userRepository.SaveAsync();
            return true;
        }
    }
}

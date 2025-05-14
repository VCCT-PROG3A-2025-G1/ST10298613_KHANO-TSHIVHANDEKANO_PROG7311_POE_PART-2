using PROG7311_POE_PART_2.Interfaces;
using PROG7311_POE_PART_2.Models;
using System.Security.Cryptography;
using System.Text;

namespace PROG7311_POE_PART_2.Services
{
    public class AuthService
    {
        private readonly IUserRepository _userRepository;

        public AuthService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        // Handles user login by verifying credentials
        public async Task<User?> LoginAsync(string username, string password)
        {
            var user = await _userRepository.GetByUsernameAsync(username);
            if (user == null) return null;

            // Check hashed password match
            string hashedInput = HashPassword(password);
            return user.PasswordHash == hashedInput ? user : null;
        }

        // Adds a new user and hashes their password
        public async Task<bool> RegisterAsync(string username, string password, string role)
        {
            var existingUser = await _userRepository.GetByUsernameAsync(username);
            if (existingUser != null) return false; // username taken

            var newUser = new User
            {
                Username = username,
                PasswordHash = HashPassword(password),
                Role = role
            };

            await _userRepository.AddAsync(newUser);
            await _userRepository.SaveAsync();
            return true;
        }

        // Simple SHA256 hash for password security
        private string HashPassword(string password)
        {
            using var sha = SHA256.Create();
            byte[] bytes = sha.ComputeHash(Encoding.UTF8.GetBytes(password));
            return Convert.ToBase64String(bytes);
        }
    }
}

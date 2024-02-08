using AllocationTeamAPI.Models;
using AllocationTeamAPI.Repositories;
using System.Text;
using System.Security.Cryptography;
using AllocationTeamAPI.Dtos;



namespace AllocationTeamAPI.Services
{
    public class UserService
    {
        private readonly IUserRepository _userRepository;
        private readonly JwtTokenService _jwtTokenService;

        public UserService(IUserRepository userRepository, JwtTokenService jwtTokenService)
        {
            _userRepository = userRepository;
            _jwtTokenService = jwtTokenService;

        }

        public async Task<bool> RegisterUser(UserDto userDto)
        {
            var users = await _userRepository.GetAllUsersAsync();
            if (users.Any(u => u.Username == userDto.Username || u.Email == userDto.Email))
            {
                return false;
            }

            var user = new User
            {
                Username = userDto.Username,
                PasswordHash = HashPassword(userDto.Password),
                Email = userDto.Email,
                DateCreated = DateTime.UtcNow,
                LastLogin = null,
                MatchResults = new List<MatchResult>()
            };
            await CreateUserAsync(user);
            return true;
        }

        public async Task<UserLoginResponse?> LoginUserAsync(string email, string password)
        {
            var user = await _userRepository.GetUserByEmailAsync(email);
            if (user != null && (HashPassword(password) == user.PasswordHash))
            {
                var token = _jwtTokenService.GenerateToken(user); 
                user.LastLogin = DateTime.UtcNow;
                await _userRepository.UpdateUserAsync(user);
                return new UserLoginResponse(user.Id,user.Username,user.Email, token);
            }
            return null;
        }


        private string HashPassword(string password)
        {
            using (var sha256 = SHA256.Create())
            {
                var hashedBytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(password));
                return BitConverter.ToString(hashedBytes).Replace("-", "").ToLower();
            }
        }

        public async Task<IEnumerable<User>> GetAllUsersAsync()
        {
            return await _userRepository.GetAllUsersAsync();
        }

        public async Task<User> GetUserByIdAsync(int userId)
        {
            return await _userRepository.GetUserByIdAsync(userId);
        }

        public async Task<User> CreateUserAsync(User user)
        {
            return await _userRepository.CreateUserAsync(user);
        }

        public async Task<User> UpdateUserAsync(User user)
        {
            return await _userRepository.UpdateUserAsync(user);
        }

        public async Task DeleteUserAsync(int userId)
        {
            await _userRepository.DeleteUserAsync(userId);
        }
    }
}

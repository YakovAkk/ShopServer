
using DataDomain.Data.Sql.Models;
using Repositories.Repositories.Base;
using Services.Services.Base;

namespace Services.Services
{
    public class UserService : IUserService
    {
        private readonly BaseRepository<UserModel> _userRepository;

        public async Task<List<UserModel>> GetAllUsersAsync()
        {
           return await _userRepository.GetAllAsync();
        }

        public async Task<UserModel> RegisterUserAsync(UserModel loginUser)
        {
            return await _userRepository.CreateAsync(loginUser);
        }

        public async Task<UserModel> LoginUserAsync(UserModel loginUser)
        {
            return await _userRepository.LoginAsync(loginUser);
        }

        public async Task LogoutUserAsync()
        {
            await _userRepository.LogoutAsync();
        }

        public async Task<UserModel> FindByEmailAsync(string usersEmail)
        {
          return await _userRepository.FindUserByEmailAsync(usersEmail);
        }

        public UserService(BaseRepository<UserModel> baseRepository)
        {
            _userRepository = baseRepository;
        }
    }
}

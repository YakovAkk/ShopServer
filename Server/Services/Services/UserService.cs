
using DataDomain.Data.Sql.Models;
using Repositories.Repositories.Base;
using Services.Services.Base;

namespace Services.Services
{
    public class UserService : IUserService
    {
        private readonly BaseRepository<UserModel> _userRepository;

        public async Task<List<UserModel>> GetAllUsers()
        {
           return await _userRepository.GetAll();
        }

        public async Task<UserModel> RegisterUser(UserModel loginUser)
        {
            return await _userRepository.Create(loginUser);
        }

        public async Task<UserModel> LoginUser(UserModel loginUser)
        {
            return await _userRepository.Login(loginUser);
        }

        public async Task LogoutUser()
        {
            await _userRepository.Logout();
        }

        public async Task<UserModel> FindByEmail(string usersEmail)
        {
          return await _userRepository.FindUserByEmail(usersEmail);
        }

        public UserService(BaseRepository<UserModel> baseRepository)
        {
            _userRepository = baseRepository;
        }
    }
}

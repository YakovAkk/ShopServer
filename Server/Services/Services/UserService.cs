
using DataDomain.Data.Sql.Models;
using Repositories.Repositories.Base;
using Services.Services.Base;
using System.Security.Claims;

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

        public async Task<ClaimsIdentity> LoginUser(UserModel loginUser)
        {
            var user = await _userRepository.Login(loginUser);
            if (user == null)
            {
                return null; 
            }
            var claims = new List<Claim>
                {
                    new Claim(ClaimsIdentity.DefaultNameClaimType, user.Name),
                };
            ClaimsIdentity claimsIdentity =
            new ClaimsIdentity(claims, "Token", ClaimsIdentity.DefaultNameClaimType,
                ClaimsIdentity.DefaultRoleClaimType);
            return claimsIdentity;
            // если пользователя не найдено

        }

        public async Task LogoutUser()
        {
            await _userRepository.Logout();
        }

        public UserService(BaseRepository<UserModel> baseRepository)
        {
            _userRepository = baseRepository;
        }
    }
}

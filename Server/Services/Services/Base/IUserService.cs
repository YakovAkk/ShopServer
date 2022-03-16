
using DataDomain.Data.Sql.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Services.Base
{
    public interface IUserService
    {
        Task<UserModel> FindByEmailAsync(string usersEmail);
        Task<List<UserModel>> GetAllUsersAsync();
        Task<UserModel> RegisterUserAsync(UserModel loginUser);
        Task<UserModel> LoginUserAsync(UserModel loginUser);
        Task LogoutUserAsync();
    }
}

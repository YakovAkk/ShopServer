
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

        Task<List<UserModel>> GetAllUsers();
        Task<UserModel> RegisterUser(UserModel loginUser);
        Task<UserModel> LoginUser(UserModel loginUser);
        Task LogoutUser();
    }
}

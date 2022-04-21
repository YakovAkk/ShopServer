
using DataDomain.Data.Sql.Database;
using DataDomain.Data.Sql.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Repositories.Repositories.Base;

namespace Repositories.Repositories
{
    public class UserRepository : BaseRepository<UserModel>
    {

        private readonly UserManager<IdentityUser> _userManager;
        private readonly SignInManager<IdentityUser> _signInManager;

        public UserRepository(AppDBContent appDBContent ,
            UserManager<IdentityUser> userManager,
            SignInManager<IdentityUser> signInManager) : base(appDBContent)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        public override async Task<bool> isDataBaseHasUser(UserModel item)
        {
            if (item == null)
            {
                return false;
            }

            var result = await _db.Users.FirstOrDefaultAsync(u => (u.NickName == item.NickName) 
            || (u.Email == item.Email));

            return (result) == null ? false : true;
        }
        public override async Task<UserModel> CreateAsync(UserModel item)
        {
            if (item == null)
            {
                var User = new UserModel();
                User.messageThatWrong = "Item was null";
                return User;
            }


            var user = new IdentityUser()
            {
                UserName = item.Name,
                Email = item.Email
            };

            var result = await _userManager.CreateAsync(user, item.Password);

            if (result.Succeeded)
            {
                await _db.Users.AddAsync(item);
                _db.SaveChanges();
                return item;
            }
            else
            {
                var User = new UserModel();
                User.messageThatWrong = "Error when creating user \n";
               
                foreach (var res in result.Errors)
                {
                    User.messageThatWrong += res;
                    User.messageThatWrong += "\n";
                }

                return User;
            }
        }
        public override async Task<UserModel> FindUserByEmailAsync(string usersEmail)
        {
            if (usersEmail == null)
            {
                var User = new UserModel();
                User.messageThatWrong = "Email was empty";
                return User;
            }

            var result = await _db.Users.FirstOrDefaultAsync(u => u.Email == usersEmail);

            if(result == null)
            {
                var User = new UserModel();
                User.messageThatWrong = "The element hasn't contained in database";
                return User;
            }

            return result;
        }
        public override async Task<List<UserModel>> GetAllAsync()
        {
            return await _db.Users.ToListAsync();
        }
        public async override Task<UserModel> LoginAsync(UserModel item)
        {
            var result = await _signInManager.PasswordSignInAsync(item.Name,
                     item.Password, item.RememberMe, false);

            if (result.Succeeded)
            {
                var user = await _db.Users.FirstOrDefaultAsync(u => u.Name == item.Name);

                if(user == null)
                {
                    var User = new UserModel();
                    User.messageThatWrong = "The user hasn't contained in database";
                    return User;
                }

                return user; 
            }
            else
            {

                var User = new UserModel();
                User.messageThatWrong = "The user hasn't contained in database";
                return User;

            }
        }
        public override async Task LogoutAsync()
        {
            await _signInManager.SignOutAsync();
        }
    }
}

﻿
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

        public override async Task<UserModel> Create(UserModel item)
        {
            var user = new IdentityUser
            {
                UserName = item.Name,
                Email = item.Email
            };
            var result = await _userManager.CreateAsync(user, item.Password);

            if (result.Succeeded)
            {
                //await _signInManager.SignInAsync(user, isPersistent: false);
                await _db.Users.AddAsync(item);
                _db.SaveChanges();
                return item;
            }

            return null;
            
        }

        public override async Task<List<UserModel>> GetAll()
        {
            return await _db.Users.ToListAsync();
        }

        public async override Task<UserModel> Login(UserModel item)
        {
            var result = await _signInManager.PasswordSignInAsync(item.Name,
                     item.Password, item.RememberMe, false);

            if (result.Succeeded)
            {
                return item; 
            }
            return null;

            
        }

        public override async Task Logout()
        {
            await _signInManager.SignOutAsync();
        }
    }
}
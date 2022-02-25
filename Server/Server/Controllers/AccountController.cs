using DataDomain.Data.Sql.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Server.DTO;
using Services.Services.Base;

namespace Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [AllowAnonymous] 
    public class AccountController : ControllerBase
    {
        private IUserService _userService;
        [HttpPost("Register")]
        public async Task<IActionResult> RegisterUser([FromBody] UserRegistrationDTO registrationUser)
        {
            var user = new UserModel()
            {
                NickName = registrationUser.NickName,
                Name = registrationUser.Email,
                Email = registrationUser.Email,
                Password = registrationUser.Password
            };
            return Ok(await _userService.RegisterUser(user));
        }
        [HttpPost("Login")]
        public async Task<IActionResult> LoginUser([FromBody] UserLoginDTO loginUser)
        {
            var user = new UserModel()
            {
                Name = loginUser.Email,
                Email = loginUser.Email,
                Password = loginUser.Password,
                RememberMe = loginUser.RememberMe
            };

            return Ok(await _userService.LoginUser(user));
        }
        [HttpPost("Logout")]
        public async Task<IActionResult> logoutUser()
        {
            await _userService.LogoutUser();
            return Ok();
        }
        public AccountController(IUserService userService)
        {
            _userService = userService;
        }

    }
}

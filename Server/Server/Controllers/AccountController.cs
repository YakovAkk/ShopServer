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
        private readonly IUserService _userService;
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

            if(await _userService.isDBHasUser(user))
            {
                var message = new
                {
                    result = "The user has already been included to database "
                };
                return BadRequest(message);
            }

            return Ok(await _userService.RegisterUserAsync(user));
        }
        [HttpPost("Login")]
        public async Task<IActionResult> LoginUser([FromBody] UserLoginDTO loginUser)
        {
            if (loginUser == null || string.IsNullOrEmpty(loginUser.Email) || string.IsNullOrEmpty(loginUser.Password))
            {
                return BadRequest("Input data not valid");
            }

            var user = new UserModel()
            {
                Name = loginUser.Email,
                Email = loginUser.Email,
                Password = loginUser.Password,
                RememberMe = loginUser.RememberMe
            };

            var loggedInModel = await _userService.LoginUserAsync(user);
            if (loggedInModel == null)
            {
                return BadRequest("User can not be logged in, check your credentials!");
            }

            return Ok(loggedInModel);
        }
        [HttpPost("Logout")]
        public async Task<IActionResult> logoutUser([FromBody] UserLoginDTO loginUser)
        {
            await _userService.LogoutUserAsync();
            return Ok(loginUser);
        }
        public AccountController(IUserService userService)
        {
            _userService = userService;
        }

    }
}

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
        public AccountController(IUserService userService)
        {
            _userService = userService;
        }

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

            var isHasUser = await _userService.isDBHasUser(user);

            if (isHasUser)
            {
                var message = new
                {
                    result = "The user has already been included to database "
                };
                return BadRequest(message);
            }

           var userModel = await _userService.RegisterUserAsync(user);

           if(userModel.messageThatWrong != null)
           {
                return BadRequest(userModel.messageThatWrong);
           }

           return Ok(userModel);
        }

        [HttpPost("Login")]
        public async Task<IActionResult> LoginUser([FromBody] UserLoginDTO loginUser)
        {
            if (loginUser == null || string.IsNullOrEmpty(loginUser.Email) || string.IsNullOrEmpty(loginUser.Password))
            {
                var message = new
                {
                    result = "login or email is empty"
                };
                return BadRequest(message);
            }

            var user = new UserModel()
            {
                Name = loginUser.Email,
                Email = loginUser.Email,
                Password = loginUser.Password,
                RememberMe = loginUser.RememberMe
            };

            var loggedInModel = await _userService.LoginUserAsync(user);

            if (loggedInModel.messageThatWrong != null)
            {
                return BadRequest(loggedInModel.messageThatWrong);
            }

            return Ok(loggedInModel);
        }

        [HttpPost("Logout")]
        public async Task<IActionResult> logoutUser([FromBody] UserLoginDTO loginUser)
        {
            await _userService.LogoutUserAsync();
            return Ok(loginUser);
        }
    }
}

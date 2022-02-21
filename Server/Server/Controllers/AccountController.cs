using DataDomain.Data.Sql.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
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
        public async Task<IActionResult> RegisterUser([FromBody] UserModel loginUser)
        {
            return Ok(await _userService.RegisterUser(loginUser));
        }
        [HttpPost("Login")]
        public async Task<IActionResult> LoginUser([FromBody] UserModel loginUser)
        {
            return Ok(await _userService.LoginUser(loginUser));
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

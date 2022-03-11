using DataDomain.Data.Sql.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using Server.DTO;
using Server.Token;
using Services.Services.Base;
using System.IdentityModel.Tokens.Jwt;

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

            var authUser = await _userService.LoginUser(user);

            if (authUser == null)
            {
                return BadRequest(new { errorText = "Invalid username or password." });
            }

            var now = DateTime.UtcNow;

            var jwt = new JwtSecurityToken(
                    issuer: AuthOptions.ISSUER,
                    audience: AuthOptions.AUDIENCE,
                    notBefore: now,
                    claims: authUser.Claims,
                    expires: now.Add(TimeSpan.FromMinutes(AuthOptions.LIFETIME)),
                    signingCredentials: new SigningCredentials(AuthOptions.GetSymmetricSecurityKey(), SecurityAlgorithms.HmacSha256));
            var encodedJwt = new JwtSecurityTokenHandler().WriteToken(jwt);

            var response = new
            {
                access_token = encodedJwt,
                username = user.Name
            };

            return Ok(response);
        }
        [HttpPost("Logout")]
        public async Task<IActionResult> logoutUser([FromBody] UserLoginDTO loginUser)
        {
            await _userService.LogoutUser();
            return Ok(loginUser);
        }
        public AccountController(IUserService userService)
        {
            _userService = userService;
        }

    }
}

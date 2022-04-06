using DataDomain.Data.Sql.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Services.Services.Base;

namespace Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        [HttpGet]
        
        public async Task<IActionResult> GetAllUsers()
        {
            var result = await _userService.GetAllUsersAsync();
            if (result == null)
            {
                return BadRequest();
            }
            return Ok(result);
        }


        public UserController(IUserService userService)
        {
            _userService = userService;
        }

    }
}

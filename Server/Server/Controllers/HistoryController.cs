using DataDomain.Data.NoSql.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Server.DTO;
using Services.Services.Base;

namespace Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class HistoryController : ControllerBase
    {
        private readonly BaseServiceForMongo<UserHistoryModel> _historyService;
        private readonly IUserService _userService;

        public HistoryController(BaseServiceForMongo<UserHistoryModel> historyService, IUserService userService)
        {
            _historyService = historyService;
            _userService = userService;
        }

        [HttpPost]
        public async Task<IActionResult> AddToHistory([FromBody] HistoryModelDTO userHistoryDTO)
        {
            var Orsers = new List<BasketModel>();

            foreach (var item in userHistoryDTO.Orders)
            {
                Orsers.Add(new BasketModel()
                {
                    Amount = Convert.ToUInt32(item.amount),
                    Lego = item.lego,
                    User = await _userService.FindByEmailAsync(item.userEmail)
                });
            }

            var user = await _userService.FindByEmailAsync(userHistoryDTO.userEmail);

            if (user.messageThatWrong != null)
            {
                return BadRequest(user.messageThatWrong);
            }

            var userHistory = new UserHistoryModel()
            {
                Orders = Orsers,
                User = user
            };

            var result = await _historyService.AddAsync(userHistory);

            if (result.messageThatWrong != null)
            {
                return BadRequest(result.messageThatWrong);
            }

            return Ok(result);
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var result = await _historyService.GetAllAsync();

            if (result == null)
            {
                var message = new
                {
                    result = "Database hasn't any history item"
                };
                return BadRequest(message);
            }

            return Ok(result);
        }
    }
}

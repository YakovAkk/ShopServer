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

            var userHistory = new UserHistoryModel()
            {
                Orders = Orsers,
                User = await _userService.FindByEmailAsync(userHistoryDTO.userEmail)
            };

            return Ok(await _historyService.AddAsync(userHistory));
        }

        public HistoryController(BaseServiceForMongo<UserHistoryModel> historyService, IUserService userService)
        {
            _historyService = historyService;
            _userService = userService;
        }
    }
}

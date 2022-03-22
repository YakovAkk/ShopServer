using DataDomain.Data.NoSql.Models;
using DataDomain.Data.Sql.Models;
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
    public class BasketController : ControllerBase
    {
        private readonly BaseServiceForMongo<BasketModel> _basketService;
        private readonly IUserService _userService;
        [HttpPost]
        public async Task<IActionResult> AddBasketAsync([FromBody] BasketModelDTO basketModel)
        {
            var basket = new BasketModel()
            {
                Amount = Convert.ToUInt32(basketModel.amount),
                Lego = basketModel.lego,
                User = await _userService.FindByEmailAsync(basketModel.userEmail)
            };
            return Ok(await _basketService.AddAsync(basket));
            
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBasket([FromRoute] string Id)
        {
            await _basketService.DeleteAsync(Id);
            return Ok();
        }

        [HttpGet("all")]
        public async Task<IActionResult> GetAllBaskets()
        {
            return Ok(await _basketService.GetAllAsync());
        }

        [HttpPut]
        public async Task<IActionResult> UpdateBasket([FromBody] BasketModelDTO basketModel)
        {
            var basket = new BasketModel()
            {
                Amount = Convert.ToUInt32(basketModel.amount),
                Lego = basketModel.lego,
                User = await _userService.FindByEmailAsync(basketModel.userEmail)
            };

            return Ok(await _basketService.UpdateAsync(basket));
        }

        [HttpGet("id")]
        public async Task<IActionResult> GetByIdBasketAsync([FromQuery] string Id)
        {
            return Ok(await _basketService.GetByIDAsync(Id));
        }

        public BasketController(BaseServiceForMongo<BasketModel> basketService, IUserService userService)
        {
            _basketService = basketService;
            _userService = userService;
        }
    }
}

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

            var result = await _basketService.AddAsync(basket);
            if (result == null)
            {
                return BadRequest();
            }

            return Ok(result);
            
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
            var result = await _basketService.GetAllAsync();
            if (result == null)
            {
                return BadRequest();
            }

            return Ok(result);
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

            var result = await _basketService.UpdateAsync(basket);
            if (result == null)
            {
                return BadRequest();
            }

            return Ok(result);
        }

        [HttpGet("id")]
        public async Task<IActionResult> GetByIdBasketAsync([FromQuery] string Id)
        {
            var result = await _basketService.GetByIDAsync(Id);
            if (result == null)
            {
                return BadRequest();
            }

            return Ok(result);
        }

        public BasketController(BaseServiceForMongo<BasketModel> basketService, IUserService userService)
        {
            _basketService = basketService;
            _userService = userService;
        }
    }
}

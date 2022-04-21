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

        public BasketController(BaseServiceForMongo<BasketModel> basketService, IUserService userService)
        {
            _basketService = basketService;
            _userService = userService;
        }

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

            if (result.messageThatWrong != null)
            {
                return BadRequest(result.messageThatWrong);
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

            if (result.Count == 0)
            {
                var message = new
                {
                    result = "Database hasn't any lego in the basket"
                };
                return BadRequest(message);
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

            if (result.messageThatWrong != null)
            {
                return BadRequest(result.messageThatWrong);
            }

            return Ok(result);
        }

        [HttpGet("id")]
        public async Task<IActionResult> GetByIdBasketAsync([FromQuery] string Id)
        {
            var result = await _basketService.GetByIDAsync(Id);

            if (result.messageThatWrong != null)
            {
                return BadRequest(result.messageThatWrong);
            }

            return Ok(result);
        }

        
    }
}

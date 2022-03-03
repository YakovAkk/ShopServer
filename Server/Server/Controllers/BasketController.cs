using DataDomain.Data.NoSql.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Services.Services.Base;

namespace Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class BasketController : ControllerBase
    {
        BaseServiceForMongo<BasketModel> _basketService;

        [HttpPost]
        public async Task<IActionResult> AddBasket([FromBody] BasketModel basketModel)
        {
            return Ok(await _basketService.Add(basketModel));
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBasket([FromQuery] string Id)
        {
            await _basketService.Delete(Id);
            return Ok();
        }

        [HttpGet("all")]
        public async Task<IActionResult> GetAllBaskets()
        {
            return Ok(await _basketService.GetAll());
        }

        [HttpPut]
        public async Task<IActionResult> UpdateBasket([FromBody] BasketModel basketModel)
        {
            return Ok(await _basketService.Update(basketModel));
        }

        [HttpGet("id")]
        public async Task<IActionResult> GetByIdBasket([FromQuery] string Id)
        {
            return Ok(await _basketService.GetByID(Id));
        }

        public BasketController(BaseServiceForMongo<BasketModel> basketService)
        {
            _basketService = basketService;
        }
    }
}

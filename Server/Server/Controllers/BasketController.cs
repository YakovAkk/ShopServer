using DataDomain.Data.NoSql.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Services.Services.Base;

namespace Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BasketController : ControllerBase
    {
        BaseServiceForMongo<BasketModel> _basketService;

        [HttpPost("addlego")]
        public async Task<IActionResult> AddLego([FromBody] BasketModel legoModel)
        {
            return Ok(await _basketService.Add(legoModel));
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteLego([FromQuery] string Id)
        {
            await _basketService.Delete(Id);
            return Ok();
        }

        [HttpGet("all")]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _basketService.GetAll());
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] BasketModel legoModel)
        {
            return Ok(await _basketService.Update(legoModel));
        }

        [HttpGet("id")]
        public async Task<IActionResult> GetById([FromQuery] string Id)
        {
            return Ok(await _basketService.GetByID(Id));
        }

        public BasketController(BaseServiceForMongo<BasketModel> basketService)
        {
            _basketService = basketService;
        }
    }
}

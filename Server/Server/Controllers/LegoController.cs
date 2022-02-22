using DataDomain.Data.NoSql.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Services.Services.Base;

namespace Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LegoController : ControllerBase
    {
        BaseServiceForMongo<LegoModel> _legoService;

        [HttpPost("addlego")]
        public async Task<IActionResult> AddLego([FromBody] LegoModel legoModel)
        {
            return Ok(await _legoService.Add(legoModel));
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteLego([FromQuery] string Id)
        {
            await _legoService.Delete(Id);
            return Ok();
        }

        [HttpGet("all")]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _legoService.GetAll());
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] LegoModel legoModel)
        {
            return Ok(await _legoService.Update(legoModel));
        }

        [HttpGet("id")]
        public async Task<IActionResult> GetById([FromQuery] string Id)
        {
            return Ok(await _legoService.GetByID(Id));
        }

        public LegoController(BaseServiceForMongo<LegoModel> legoService)
        {
            _legoService = legoService;
        }
    }
}

using DataDomain.Data.NoSql.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Services.Services.Base;

namespace Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [AllowAnonymous] // delete when add Lego to database
    public class LegoController : ControllerBase
    {
        BaseServiceForMongo<LegoModel> _legoService;

        [HttpPost]
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
        public async Task<IActionResult> GetAllLego()
        {
            return Ok(await _legoService.GetAll());
        }

        [HttpPut]
        public async Task<IActionResult> UpdateLego([FromBody] LegoModel legoModel)
        {
            return Ok(await _legoService.Update(legoModel));
        }

        [HttpGet("id")]
        public async Task<IActionResult> GetByIdLego([FromQuery] string Id)
        {
            return Ok(await _legoService.GetByID(Id));
        }

        public LegoController(BaseServiceForMongo<LegoModel> legoService)
        {
            _legoService = legoService;
        }
    }
}

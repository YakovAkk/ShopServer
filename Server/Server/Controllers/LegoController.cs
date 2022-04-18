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
        private readonly BaseServiceForMongo<LegoModel> _legoService;

        [HttpPost]
        public async Task<IActionResult> AddLego([FromBody] LegoModel legoModel)
        {
            var result = await _legoService.AddAsync(legoModel);
            if (result == null)
            {
                return BadRequest();
            }
            return Ok(result);
         
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteLego([FromQuery] string Id)
        {
            await _legoService.DeleteAsync(Id);
            return Ok();
        }

        [HttpGet("all")]
        public async Task<IActionResult> GetAllLego()
        {
            var result = await _legoService.GetAllAsync();
            if (result == null)
            {
                return BadRequest();
            }
            return Ok(result);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateLego([FromBody] LegoModel legoModel)
        {
            var result = await _legoService.UpdateAsync(legoModel);
            if (result == null)
            {
                return BadRequest();
            }
            return Ok(result);
        }

        [HttpGet("id")]
        public async Task<IActionResult> GetByIdLego([FromQuery] string Id)
        {
            var result = await _legoService.GetByIDAsync(Id);
            if (result == null)
            {
                return BadRequest();
            }
            return Ok(result);
        }

        public LegoController(BaseServiceForMongo<LegoModel> legoService)
        {
            _legoService = legoService;
        }
    }
}

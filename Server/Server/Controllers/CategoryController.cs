using DataDomain.Data.NoSql.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Services.Services.Base;

namespace Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        BaseServiceForMongo<CategoryModel> _categoryService;

        [HttpPost("addlego")]
        public async Task<IActionResult> AddLego([FromBody] CategoryModel legoModel)
        {
            return Ok(await _categoryService.Add(legoModel));
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteLego([FromQuery] string Id)
        {
            await _categoryService.Delete(Id);
            return Ok();
        }

        [HttpGet("all")]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _categoryService.GetAll());
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] CategoryModel legoModel)
        {
            return Ok(await _categoryService.Update(legoModel));
        }

        [HttpGet("id")]
        public async Task<IActionResult> GetById([FromQuery] string Id)
        {
            return Ok(await _categoryService.GetByID(Id));
        }

        public CategoryController(BaseServiceForMongo<CategoryModel> categoryService)
        {
            _categoryService = categoryService;
        }
    }
}

using DataDomain.Data.NoSql.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Services.Services.Base;

namespace Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [AllowAnonymous] // delete when add Category to database
    public class CategoryController : ControllerBase
    {
        private readonly BaseServiceForMongo<CategoryModel> _categoryService;

        public CategoryController(BaseServiceForMongo<CategoryModel> categoryService)
        {
            _categoryService = categoryService;
        }

        [HttpPost]
        public async Task<IActionResult> AddCategory([FromBody] CategoryModel categoryModel)
        {
            var result = await _categoryService.AddAsync(categoryModel);

            if (result.messageThatWrong != null)
            {
                return BadRequest(result.messageThatWrong);
            }

            return Ok(result);
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCategory([FromQuery] string Id)
        {
            await _categoryService.DeleteAsync(Id);
            return Ok();
        }

        [HttpGet("all")]
        public async Task<IActionResult> GetAllCategories()
        {
            var result = await _categoryService.GetAllAsync();

            if (result == null)
            {
                var message = new
                {
                    result = "Database hasn't any category"
                };
                return BadRequest(message);
            }

            return Ok(result);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateCategory([FromBody] CategoryModel categoryModel)
        {
            var result = await _categoryService.UpdateAsync(categoryModel);
            if (result.messageThatWrong != null)
            {
                return BadRequest(result.messageThatWrong);
            }
            return Ok(result);
        }

        [HttpGet("id")]
        public async Task<IActionResult> GetByIdCategory([FromQuery] string Id)
        {
            var result = await _categoryService.GetByIDAsync(Id);
            if (result.messageThatWrong != null)
            {
                return BadRequest(result.messageThatWrong);
            }
            return Ok(result);
        }    
    }
}

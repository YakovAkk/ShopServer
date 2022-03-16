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

        [HttpPost]
        public async Task<IActionResult> AddCategory([FromBody] CategoryModel categoryModel)
        {
            return Ok(await _categoryService.AddAsync(categoryModel));
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
            return Ok(await _categoryService.GetAllAsync());
        }

        [HttpPut]
        public async Task<IActionResult> UpdateCategory([FromBody] CategoryModel categoryModel)
        {
            return Ok(await _categoryService.UpdateAsync(categoryModel));
        }

        [HttpGet("id")]
        public async Task<IActionResult> GetByIdCategory([FromQuery] string Id)
        {
            return Ok(await _categoryService.GetByIDAsync(Id));
        }

        public CategoryController(BaseServiceForMongo<CategoryModel> categoryService)
        {
            _categoryService = categoryService;
        }
    }
}

using GonoPic.Application.DTOs;
using GonoPic.Application.Interfaces;
using GonoPic.Application.Mappers;
using GonoPic.Domain.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace GonoPic.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryService _categoryService;

        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var categoryList = await _categoryService.GetAllCategoriesAsync();

            var categoryDtos = categoryList.Select(CategoryMapper.ToDto);
            return Ok(categoryDtos);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var category = await _categoryService.GetCategoryByIdAsync(id);
            if (category == null) 
                return NotFound();

            var categoryDto = CategoryMapper.ToDto(category);
            return Ok(category);
        }

        [HttpGet("name/{name}")]
        public async Task<IActionResult> GetByName(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
                return BadRequest(new { Message = "Category name cannot be empty." });

            var category = await _categoryService.GetCategoryByNameAsync(name);
            if (category == null)
                return NotFound();

            var categoryDto = CategoryMapper.ToDto(category);
            return Ok(categoryDto);
        }

        [HttpGet("{id}/media")]
        public async Task<IActionResult> GetMediaByCategory(int id)
        {
            var category = await _categoryService.GetCategoryByIdAsync(id);
            if (category == null)
                return NotFound();

            var mediaItems =  category.MediaItems ?? new List<Media>();
            if (mediaItems == null || !mediaItems.Any())
                return NotFound(new { Message = $"No media found for category '{category.Name}'." });

            var mediaDtos = mediaItems.Select(MediaMapper.ToDto);
            return Ok(mediaDtos);
        }

        [HttpPost]
        [Authorize(Roles = "Admin, Editor")]
        public async Task<IActionResult> Create(CategoryCreateDto dto)
        {
            var existingCategory = await _categoryService.GetCategoryByNameAsync(dto.Name);
            if (existingCategory != null)
                return Conflict(new { Message = $"A category with the name '{dto.Name}' already exists." });

            var category = CategoryMapper.ToEntity(dto);
            
            var result = await _categoryService.CreateCategoryAsync(category);
            if (!result)
                return BadRequest(new { message = "Failed to create categoory" });

            return Ok(new {message = "Category created successfully"});
        }

        [HttpPost("{id}")]
        [Authorize(Roles = "Admin, Editor")]
        public async Task<IActionResult> Update(int id, CategoryUpdateDto dto)
        {
            var category = await _categoryService.GetCategoryByIdAsync(id);
            if (category == null)
                return NotFound();

            CategoryMapper.UpdateEntity(dto, category);

            var result = await _categoryService.UpdateCategoryAsync(category);
            if (!result)
                return BadRequest(new { message = "Failed to update categoory" });

            return NoContent();
        }

        [HttpDelete("{id}")]
        [Authorize(Roles = "Admin, Editor")]
        public async Task<IActionResult> Delete(int id)
        {
            var category = await _categoryService.GetCategoryByIdAsync(id);
            if (category == null)
                return NotFound();

            var result = await _categoryService.DeleteCategoryAsync(category);
            if (!result)
                return BadRequest(new { message = "Failed to delete categoory" });

            return NoContent();
        }
    }
}

using LostAndFoundAPI.Application.DTOs;
using LostAndFoundAPI.Application.Repositories;
using LostAndFoundAPI.Domain.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace LostAndFoundAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CategoriesController : ControllerBase
{
    private readonly ICategoryRepository _repository;

    public CategoriesController(ICategoryRepository repository)
    {
        _repository = repository;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<CategoryDto>>> GetAll()
    {
        var categories = await _repository.GetAllAsync();

        var result = categories.Select(c => new CategoryDto
        {
            Id = c.Id,
            Name = c.Name
        }).ToList();

        return Ok(result);
    }
    
    [Authorize(Roles = "Admin")]
    [HttpDelete("{id:int}")]
    public async Task<IActionResult> Delete(int id)
    {
        var category = await _repository.GetByIdAsync(id);

        if (category == null)
            return NotFound();

        await _repository.DeleteAsync(id);

        return NoContent();
    }
    
    [HttpGet("admin/all")]
    public async Task<ActionResult<IEnumerable<CategoryListItemDto>>> GetAllForAdmin()
    {
        var categories = await _repository.GetAllForAdminAsync();
        return Ok(categories);
    }

    [Authorize(Roles = "Admin")]
    [HttpPost("admin")]
    public async Task<ActionResult<CategoryDto>> CreateAsync(CreateCategoryDto dto)
    {
        var name = dto.Name?.Trim();

        if (string.IsNullOrWhiteSpace(name))
            return BadRequest("Category name is required.");
        
        var newCategory = new Category
        {
            Name = name
        };
        
        var createdCategory = await _repository.AddAsync(newCategory);

        return CreatedAtAction(nameof(GetAll), new { id = createdCategory.Id }, new CategoryDto
        {
            Id = createdCategory.Id,
            Name = createdCategory.Name
        });
    }
}
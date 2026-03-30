using LostAndFoundAPI.Application.DTOs;
using LostAndFoundAPI.Application.Repositories;
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
}
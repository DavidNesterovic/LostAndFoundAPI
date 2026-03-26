using LostAndFoundAPI.Application.Repositories;
using LostAndFoundAPI.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace LostAndFoundAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class FoundItemsController : ControllerBase
{
    private readonly IFoundItemRepository _repository;

    public FoundItemsController(IFoundItemRepository repository)
    {
        _repository = repository;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<FoundItem>>> GetAll()
    {
        var items = await _repository.GetAllAsync();
        return Ok(items);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<FoundItem>> GetById(int id)
    {
        var item = await _repository.GetByIdAsync(id);

        if (item == null)
            return NotFound();

        return Ok(item);
    }

    [HttpPost]
    public async Task<ActionResult<FoundItem>> Create([FromBody] FoundItem newItem)
    {
        var createdItem = await _repository.AddAsync(newItem);
        return CreatedAtAction(nameof(GetById), new { id = createdItem.Id }, createdItem);
    }
}
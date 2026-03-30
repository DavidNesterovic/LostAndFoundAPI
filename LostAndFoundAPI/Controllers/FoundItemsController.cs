using LostAndFoundAPI.Application.Repositories;
using LostAndFoundAPI.Domain.Entities;
using LostAndFoundAPI.Hubs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;

namespace LostAndFoundAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class FoundItemsController : ControllerBase
{
    private readonly IFoundItemRepository _repository;
    private readonly IHubContext<FoundItemsHub> _hubContext;

    public FoundItemsController(IFoundItemRepository repository, IHubContext<FoundItemsHub> hubContext)
    {
        _repository = repository;
        _hubContext = hubContext;
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
    [Authorize]
    public async Task<ActionResult<FoundItem>> Create([FromBody] FoundItem newItem)
    {
        var createdItem = await _repository.AddAsync(newItem);
        
        await _hubContext.Clients.All.SendAsync("FoundItemCreated", createdItem);
        
        return CreatedAtAction(nameof(GetById), new { id = createdItem.Id }, createdItem);
    }
}
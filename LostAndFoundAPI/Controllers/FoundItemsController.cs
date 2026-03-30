using LostAndFoundAPI.Application.DTOs;
using LostAndFoundAPI.Application.Repositories;
using LostAndFoundAPI.Domain.Entities;
using LostAndFoundAPI.Hubs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using System.Security.Claims;

namespace LostAndFoundAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class FoundItemsController : ControllerBase
{
    private readonly IFoundItemRepository _repository;
    private readonly IHubContext<FoundItemsHub> _hubContext;

    public FoundItemsController(
        IFoundItemRepository repository,
        IHubContext<FoundItemsHub> hubContext)
    {
        _repository = repository;
        _hubContext = hubContext;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<FoundItemDto>>> GetAll([FromQuery] int? limit)
    {
        var items = await _repository.GetAllAsync(limit);

        var result = items.Select(MapToDto).ToList();

        return Ok(result);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<FoundItemDto>> GetById(int id)
    {
        var item = await _repository.GetByIdAsync(id);

        if (item == null)
            return NotFound();

        return Ok(MapToDto(item));
    }

    [HttpPost]
    [Authorize]
    public async Task<ActionResult<FoundItemDto>> Create([FromBody] CreateFoundItemDto dto)
    {
        var currentUserId = User.FindFirstValue(ClaimTypes.NameIdentifier);
        var currentUserEmail = User.FindFirstValue(ClaimTypes.Email) ?? User.Identity?.Name ?? "keine-email@angegeben.de";

        var newItem = new FoundItem
        {
            Title = dto.Title,
            Description = dto.Description,
            Color = dto.Color,
            Location = dto.Location,
            ImageUrl = dto.ImageUrl,
            CategoryId = dto.CategoryId,

            UserId = currentUserId,
            ContactEmail = currentUserEmail
        };

        var createdItem = await _repository.AddAsync(newItem);
        var result = MapToDto(createdItem);

        await _hubContext.Clients.All.SendAsync("FoundItemCreated", result);

        return CreatedAtAction(nameof(GetById), new { id = result.Id }, result);
    }

    private static FoundItemDto MapToDto(FoundItem item)
    {
        return new FoundItemDto
        {
            Id = item.Id,
            Title = item.Title,
            Description = item.Description,
            Color = item.Color,
            Location = item.Location,
            ImageUrl = item.ImageUrl,
            ContactEmail = item.ContactEmail,
            UserId = item.UserId,
            CategoryId = item.CategoryId,
            CategoryName = item.Category.Name
        };
    }
}
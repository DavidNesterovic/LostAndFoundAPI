namespace LostAndFoundAPI.Application.DTOs;

public class CreateFoundItemDto
{
    public string Title { get; set; } = null!;
    public string Description { get; set; } = null!;
    public string Color { get; set; } = null!;
    public string Location { get; set; } = null!;
    public string? ImageUrl { get; set; }
    public int CategoryId { get; set; }
}
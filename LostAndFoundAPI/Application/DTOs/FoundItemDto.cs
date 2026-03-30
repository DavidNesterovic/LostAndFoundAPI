namespace LostAndFoundAPI.Application.DTOs;

public class FoundItemDto
{
    public int Id { get; set; }
    public string Title { get; set; } = null!;
    public string Description { get; set; } = null!;
    public string Color { get; set; } = null!;
    public string Location { get; set; } = null!;
    public string? ImageUrl { get; set; }
    public string ContactEmail { get; set; } = null!;

    public string? UserId { get; set; }

    public int CategoryId { get; set; }
    public string CategoryName { get; set; } = null!;
}
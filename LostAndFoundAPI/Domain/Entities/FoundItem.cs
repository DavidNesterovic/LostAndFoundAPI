namespace LostAndFoundAPI.Domain.Entities;

public class FoundItem
{
    public int Id { get; set; }
    public string Title { get; set; } = null!;
    public string Description { get; set; } = null!;
    public int CategoryId { get; set; }
    public Category Category { get; set; } = null!;
    public string Color { get; set; } = null!;
    public string Location { get; set; } = null!;
    public string? ImageUrl { get; set; }
    public string? UserId { get; set; }
    public string ContactEmail { get; set; } = string.Empty;
}
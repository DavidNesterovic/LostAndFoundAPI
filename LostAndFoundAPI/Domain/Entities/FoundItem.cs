namespace LostAndFoundAPI.Domain.Entities;

public class FoundItem
{
    public int Id { get; set; }
    public string Title { get; set; } = null!;
    public string Description { get; set; } = null!;
    public string Category { get; set; } = null!;
    public string Color { get; set; } = null!;
    public string Location { get; set; } = null!;
    public string? ImageUrl { get; set; }
    public string ContactName { get; set; } = null!;
    public string ContactEmail { get; set; } = null!;
}
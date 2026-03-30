namespace LostAndFoundAPI.Domain.Entities;

public class Category
{
    public int Id { get; set; }
    public string Name { get; set; } = null!;
    public ICollection<FoundItem> FoundItems { get; set; } = new List<FoundItem>();
}
using LostAndFoundAPI.Application.DTOs;
using LostAndFoundAPI.Data;
using LostAndFoundAPI.Domain.Entities;
using Microsoft.EntityFrameworkCore;


namespace LostAndFoundAPI.Application.Repositories.MySqlRepository;

public class MySqlCategoryRepository : ICategoryRepository
{
    private readonly MySqlDbContext _context;

    public MySqlCategoryRepository(MySqlDbContext context)
    {
        _context = context;
    }

    public async Task<List<Category>> GetAllAsync()
    {
        return await _context.Categories
            .OrderBy(c => c.Name)
            .ToListAsync();
    }

    public async Task<Category?> GetByIdAsync(int id)
    {
        return await _context.Categories.FindAsync(id);
    }

    public async Task<bool> DeleteAsync(int id)
    {
        var category = await _context.Categories.FindAsync(id);

        if (category == null)
            return false;

        _context.Categories.Remove(category);
        await _context.SaveChangesAsync();
        return true;
    }
    
    public async Task<IEnumerable<CategoryListItemDto>> GetAllForAdminAsync()
    {
        return await _context.Categories
            .Select(c => new CategoryListItemDto
            {
                Id = c.Id,
                Name = c.Name,
                ItemCount = c.FoundItems.Count()
            })
            .OrderBy(c => c.Name)
            .ToListAsync();
    }
    
    public async Task<bool> ExistsByNameAsync(string name)
    {
        return await _context.Categories
            .AnyAsync(c => c.Name.ToLower() == name.ToLower());
    }

    public async Task<Category> AddAsync(Category category)
    {
        _context.Categories.Add(category);
        await _context.SaveChangesAsync();
    
        return category;
    }
}
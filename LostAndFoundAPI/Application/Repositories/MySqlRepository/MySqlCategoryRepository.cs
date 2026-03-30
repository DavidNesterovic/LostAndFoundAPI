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
}
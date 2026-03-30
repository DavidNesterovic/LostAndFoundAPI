using LostAndFoundAPI.Data;
using LostAndFoundAPI.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace LostAndFoundAPI.Application.Repositories.MySqlRepository;

public class MySqlFoundItemRepository : IFoundItemRepository
{
    private readonly MySqlDbContext _context;

    public MySqlFoundItemRepository(MySqlDbContext context)
    {
        _context = context;
    }

    public async Task<List<FoundItem>> GetAllAsync(int? limit = null)
    {
        var query = _context.FoundItems
            .Include(f => f.Category)
            .OrderByDescending(f => f.Id)
            .AsQueryable();

        if (limit.HasValue)
        {
            query = query.Take(limit.Value);
        }

        return await query.ToListAsync();
    }

    public async Task<FoundItem?> GetByIdAsync(int id)
    {
        return await _context.FoundItems
            .Include(f => f.Category)
            .FirstOrDefaultAsync(f => f.Id == id);
    }

    public async Task<FoundItem> AddAsync(FoundItem item)
    {
        _context.FoundItems.Add(item);
        await _context.SaveChangesAsync();

        await _context.Entry(item)
            .Reference(f => f.Category)
            .LoadAsync();

        return item;
    }
}
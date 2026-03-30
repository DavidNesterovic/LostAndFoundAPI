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

    public async Task<List<FoundItem>> GetAllAsync()
    {
        return await _context.FoundItems
            .Include(f => f.Category)
            .ToListAsync();
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
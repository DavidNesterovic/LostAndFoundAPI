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
        return await _context.FoundItems.ToListAsync();
    }

    public async Task<FoundItem?> GetByIdAsync(int id)
    {
        return await _context.FoundItems.FindAsync(id);
    }

    public async Task<FoundItem> AddAsync(FoundItem item)
    {
        _context.FoundItems.Add(item);
        await _context.SaveChangesAsync();
        return item;
    }
}
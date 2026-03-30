using LostAndFoundAPI.Domain.Entities;

namespace LostAndFoundAPI.Application.Repositories;

public interface IFoundItemRepository
{
    Task<List<FoundItem>> GetAllAsync(int? limit = null);
    Task<FoundItem?> GetByIdAsync(int id);

    Task<FoundItem> AddAsync(FoundItem item);
}
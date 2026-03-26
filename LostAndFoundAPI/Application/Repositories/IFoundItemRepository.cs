using LostAndFoundAPI.Domain.Entities;

namespace LostAndFoundAPI.Application.Repositories;

public interface IFoundItemRepository
{
    Task<List<FoundItem>> GetAllAsync();
    Task<FoundItem?> GetByIdAsync(int id);

    Task<FoundItem> AddAsync(FoundItem item);
}
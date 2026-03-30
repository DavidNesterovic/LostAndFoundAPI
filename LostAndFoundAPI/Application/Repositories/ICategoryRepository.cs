using LostAndFoundAPI.Domain.Entities;

namespace LostAndFoundAPI.Application.Repositories;

public interface ICategoryRepository
{
    Task<List<Category>> GetAllAsync();
}
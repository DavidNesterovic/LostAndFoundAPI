using LostAndFoundAPI.Application.DTOs;
using LostAndFoundAPI.Domain.Entities;

namespace LostAndFoundAPI.Application.Repositories;

public interface ICategoryRepository
{
    Task<List<Category>> GetAllAsync();
    Task<Category?> GetByIdAsync(int id);
    Task<bool> DeleteAsync(int id);
    Task<IEnumerable<CategoryListItemDto>> GetAllForAdminAsync();
    
    Task<Category> AddAsync(Category category);
}
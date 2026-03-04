using Microsoft.EntityFrameworkCore;

namespace LostAndFoundAPI.Data;

public class MySqlDbContext : DbContext
{
    public MySqlDbContext(DbContextOptions<MySqlDbContext> options)
        : base(options)
    {
    }
}
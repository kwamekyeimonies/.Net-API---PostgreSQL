using Microsoft.EntityFrameworkCore;

namespace PostgresSQL.Data;

public class ApiDbContext : DbContext
{
    public ApiDbContext(DbContextOptions<ApiDbContext> options) : base(options) { }
}
using Microsoft.EntityFrameworkCore;

namespace Efephant.Data;

public class Context : DbContext
{
    public DbSet<Park> Parks { get; set; } = null!;

    public Context(DbContextOptions<Context> options) : base(options)
    {
    }
}
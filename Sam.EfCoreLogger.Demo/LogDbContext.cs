using Microsoft.EntityFrameworkCore;

namespace Sam.EfCoreLogger.Demo;

public class LogDbContext(DbContextOptions<LogDbContext> options) : DbContext(options)
{
    public DbSet<Log> Logs { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlite("Data Source=MyAppDb.db");
    }
}

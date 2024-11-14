using Microsoft.EntityFrameworkCore;

namespace Sam.EfCoreLogger.Demo;

public class MyDbContextFactory(DbContextOptions<LogDbContext> options) : IDbContextFactory<LogDbContext>
{
    private readonly DbContextOptions<LogDbContext> _options = options;

    public LogDbContext CreateDbContext()
    {
        return new LogDbContext(_options);
    }
}

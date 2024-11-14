namespace Sam.EfCoreLogger.Demo;

using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

public class EfCoreLoggerProvider(IDbContextFactory<LogDbContext> logDbContextFactory) : ILoggerProvider
{
    private readonly IDbContextFactory<LogDbContext> logDbContextFactory = logDbContextFactory;

    public ILogger CreateLogger(string categoryName)
    {
        return new EfLogger(logDbContextFactory);
    }

    public void Dispose() { }
}

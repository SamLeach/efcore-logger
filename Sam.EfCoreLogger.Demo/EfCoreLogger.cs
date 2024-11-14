using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
namespace Sam.EfCoreLogger.Demo;

public class EfLogger(IDbContextFactory<LogDbContext> contextFactory) : ILogger
{
    private readonly IDbContextFactory<LogDbContext> _contextFactory = contextFactory;

    public IDisposable? BeginScope<TState>(TState state) => null;

    public bool IsEnabled(LogLevel logLevel) => true;

    public void Log<TState>(LogLevel logLevel, EventId eventId, TState state, Exception? exception, Func<TState, Exception?, string> formatter)
    {
        // New DbContext per log
        using var context = _contextFactory.CreateDbContext();

        // Confirms different instances
        Console.WriteLine($"DbContext instance HashCode: '{context.GetHashCode()}'");

        var message = formatter(state, exception);

        var logEntry = new Log
        {
            Message = message,
            Timestamp = DateTime.UtcNow
        };

        //context.Add(logEntry);
        //context.SaveChanges();
    }
}

using Microsoft.Extensions.Logging;

namespace Sam.EfCoreLogger.Demo;

public class ServiceA(ILogger<ServiceA> logger)
{
    private readonly ILogger<ServiceA> _logger = logger;

    public void DoSomething()
    {
        _logger.LogInformation("ServiceA is doing something.");
    }
}
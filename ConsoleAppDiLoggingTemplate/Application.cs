using ConsoleAppDiLoggingTemplate.Extensions;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace ConsoleAppDiLoggingTemplate;

public class Application(
    ILogger<Application> logger,
    IConfiguration configuration)
{
    // main application entrypoint
    public async Task Run(string[] args)
    {
        logger.LogInformation("Application Running...");
        
        // your code here
        logger.LogDebug("Data from configuration: {data}", configuration.GetAppSettings()?.ConfigurationMessage);
        
        // prevent program exit
        await Task.Delay(-1);
    }
}

using Microsoft.Extensions.Configuration;

namespace ConsoleAppDiLoggingTemplate.Extensions;

public static class IConfigurationExtensions
{
    public static AppSettings? GetAppSettings(this IConfiguration configuration)
    {
        return configuration.GetRequiredSection(nameof(AppSettings)).Get<AppSettings>();
    }
}
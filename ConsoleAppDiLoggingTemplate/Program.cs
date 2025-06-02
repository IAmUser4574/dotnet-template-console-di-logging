using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Serilog;

namespace ConsoleAppDiLoggingTemplate;

public abstract class Program
{
    public static async Task Main(string[] args)
    {
        var builder = new ConfigurationBuilder();
        var appConfiguration = BuildConfig(builder);

        // https://github.com/serilog/serilog/wiki/Configuration-Basics
        // https://benfoster.io/blog/serilog-best-practices/
        Log.Logger = new LoggerConfiguration()
            .ReadFrom.Configuration(appConfiguration)
            .CreateLogger();

        Log.Logger.Information("Application Starting");

        var host = Host.CreateDefaultBuilder()
            .ConfigureServices((context, services) =>
            {
                services.AddSingleton<Application>();
                services.AddSingleton<IConfiguration>(provider => appConfiguration);
                // add application service injections here
            })
            .UseSerilog()
            .Build();

        _services = host.Services.CreateScope().ServiceProvider;

        await _services.GetRequiredService<Application>().Run(args);
    }
    
    private static IServiceProvider? _services;
    
    public static TService? GetService<TService>()
    {
        return _services != null ? _services.GetService<TService>() : default;
    }
    
    static IConfigurationRoot BuildConfig(IConfigurationBuilder builder)
    {
        builder.SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile(@"appsettings.json", optional: false, reloadOnChange: true)  // .json file must be set to "Content" & "Copy Always" or "Copy if newer"
            .AddEnvironmentVariables();

        return builder.Build();
    }
}

public class AppSettings
{
    public required string ConfigurationMessage { get; init; }
    public required int ConfigurationNumber { get; init; }
    public required bool IsThisConfiguredCorrectly { get; init; }
}
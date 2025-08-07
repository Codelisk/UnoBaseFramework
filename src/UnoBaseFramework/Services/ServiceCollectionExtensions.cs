using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Localization;
using Microsoft.Extensions.Logging;
using Uno.Extensions;
using Uno.Extensions.Configuration;
using Uno.Extensions.Hosting;
using Uno.Extensions.Localization;
using Uno.Extensions.Logging;
using Uno.Extensions.Navigation;
using Uno.Extensions.Reactive;
using Uno.Extensions.Serialization;

namespace UnoBaseFramework.Services;

public static class ServiceCollectionExtensions
{
    public static IHostBuilder ConfigureUnoBaseFramework(this IHostBuilder hostBuilder)
    {
        return hostBuilder
            .UseLogging(configure: (context, logBuilder) =>
            {
                // Configure logging
                logBuilder
                    .SetMinimumLevel(LogLevel.Information)
                    .ConfigureExtensions(ext =>
                        ext.EnableUnoLogging());
            })
            .UseConfiguration(configure: configBuilder =>
                configBuilder
                    .EmbeddedSource<App>()
                    .Section<AppInfo>()
            )
            .UseLocalization()
            .UseToolkitNavigation()
            .UseSerialization()
            .UseHttp()
            .UseReactive()
            .ConfigureServices((context, services) =>
            {
                // Register base services
                services.AddSingleton<IStringLocalizer, StringLocalizer>();
            });
    }

    public static IServiceCollection AddBaseViewModels(this IServiceCollection services)
    {
        // Extension point for registering ViewModels
        return services;
    }

    public static IServiceCollection AddBaseServices(this IServiceCollection services)
    {
        // Extension point for registering services
        return services;
    }

    public static IServiceCollection AddBaseRepositories(this IServiceCollection services)
    {
        // Extension point for registering repositories
        return services;
    }
}

public record AppInfo
{
    public string? Title { get; init; }
    public string? Version { get; init; }
}
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Uno.Extensions.Navigation;

namespace UnoBaseFramework.Services;

public static class NavigationExtensions
{
    public static IServiceCollection AddBaseNavigation(this IServiceCollection services)
    {
        // Base navigation registration
        return services;
    }

    public static RouteMapBuilder RegisterBaseRoutes(this RouteMapBuilder routeMap)
    {
        // Extension point for route registration
        return routeMap;
    }
}
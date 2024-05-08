using antapp.GameMap.Builders;
using antapp.GameMap.Services;
using Microsoft.Extensions.DependencyInjection;

namespace antapp.GameMap;

public static class GameMapModule
{
    public static void AddGameMapModule(this IServiceCollection services)
    {
        services.AddScoped<IGameMapService, GameMapService>();
        services.AddScoped<IGameMapViewModelBuilder, GameMapViewModelBuilder>();
    }
}

using antapp.LeaderBoard.Builders;
using antapp.LeaderBoard.Services;
using Microsoft.Extensions.DependencyInjection;

namespace antapp.LeaderBoard;

public static class LeaderBoardModule
{
    public static void AddLeaderBoardModule(this IServiceCollection services)
    {
        services.AddScoped<ILeaderBoardViewModelBuilder, LeaderBoardViewModelBuilder>();
        services.AddScoped<ILeaderBoardService, LeaderBoardService>();
    }
}

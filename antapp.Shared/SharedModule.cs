using antapp.Shared.Auth;
using Microsoft.Extensions.DependencyInjection;

namespace antapp.Shared;

public static class SharedModule
{
    public static void AddSharedModule(this IServiceCollection services)
    {
        services.AddScoped<IUserAccesor, DummyUser>();
    }
}

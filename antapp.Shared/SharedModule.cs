using antapp.Shared.Auth;
using antapp.Shared.Auth.DbConnection;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using antapp.Shared.Auth.Services;


namespace antapp.Shared;

public static class SharedModule
{
    public static void AddSharedModule(this IServiceCollection services, string db)
    {
        services.AddScoped<IUserAccesor, DummyUser>();
        services.AddDbContext<AppDbContext>(options => options.UseNpgsql(db));
        services.AddDbContext<antappDbContext>(options => options.UseNpgsql(db));
        services.AddScoped<IAuthenticationService, AuthenticationService>();
        services.AddSingleton(Random.Shared);
    }
}

using antapp.UserMenu.Builders;
using antapp.UserMenu.Services;
using Microsoft.Extensions.DependencyInjection;

namespace antapp.UserMenu;

public static class UserMenuModule
{
    public static void AddUserMenuModule(this IServiceCollection services)
    {
        services.AddScoped<IUserMenuViewModelBuilder, UserMenuViewModelBuilder>();
        services.AddScoped<IUserAntsService, UserAntService>();
    }
}

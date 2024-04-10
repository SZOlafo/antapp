using Microsoft.Extensions.DependencyInjection;

namespace antapp.LoginService;

public static class LoginServiceModule
{
    public static void AddLoginServiceModule(this IServiceCollection services)
    {
        //services.AddScoped<ILoginServiceVievModelBuilder, LoginServiceVievModelBuilder>();
        //services.AddScoped<DBtest, DBtest>();
    }
}

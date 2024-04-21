using antapp.Chat.Builders;
using antapp.Chat.Services;
using Microsoft.Extensions.DependencyInjection;

namespace antapp.Chat;

public static class ChatModule
{
    public static void AddChatModule(this IServiceCollection services)
    {
        services.AddScoped<IChatViewModelBuilder, ChatViewModelBuilder>();
        services.AddScoped<IChatService, ChatService>();
    }

}

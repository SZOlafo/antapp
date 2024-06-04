using antapp.Chat.Services;
using antapp.Chat.ViewModels;
using antapp.Shared.Auth;


namespace antapp.Chat.Builders;

public interface IChatListViewModelBuilder
{
    Task<ChatListViewModel> Build(string userId);
}
internal class ChatListViewModelBuilder: IChatListViewModelBuilder
{
    private readonly IChatListService _chatListService;

    public ChatListViewModelBuilder(IChatListService chatListService)
    {
        _chatListService = chatListService;
    }

    public async Task<ChatListViewModel> Build(string userId)
    {
        return new ChatListViewModel
        {
            Chats = await _chatListService.GetChat(userId),
        };
    }
}

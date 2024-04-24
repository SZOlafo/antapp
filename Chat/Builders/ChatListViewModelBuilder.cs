using antapp.Chat.Services;
using antapp.Chat.ViewModels;


namespace antapp.Chat.Builders;

public interface IChatListViewModelBuilder
{
    Task<ChatListViewModel> Build();
}
internal class ChatListViewModelBuilder: IChatListViewModelBuilder
{
    private readonly IChatListService _chatListService;

    public ChatListViewModelBuilder(IChatListService chatListService)
    {
        _chatListService = chatListService;
    }

    public async Task<ChatListViewModel> Build()
    {
        return new ChatListViewModel
        {
            Chats = await _chatListService.GetChat(),
        };
    }
}

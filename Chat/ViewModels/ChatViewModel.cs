using antapp.Shared.Auth.Dtos;

namespace antapp.Chat.ViewModels;

public class ChatViewModel
{
    public required ChatDto Chat {  get; set; }
    public required List<ChatEntryDto> Entries { get; set; }
}

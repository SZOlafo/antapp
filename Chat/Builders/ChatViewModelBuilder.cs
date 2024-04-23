using antapp.Chat.Services;
using antapp.Chat.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace antapp.Chat.Builders
{

    public interface IChatViewModelBuilder
    {
        Task<ChatViewModel> Build(int chatId);
    }
    internal class ChatViewModelBuilder : IChatViewModelBuilder
    {
        private readonly IChatService _chatService;

        public ChatViewModelBuilder(IChatService chatService)
        {
            _chatService = chatService;
        }

        public async Task<ChatViewModel> Build(int chatId)
        {
            return new ChatViewModel
            {
                Chat = await _chatService.GetChat(chatId),
                Entries = await _chatService.GetChatEntries(chatId),
            };
        }
    }
}

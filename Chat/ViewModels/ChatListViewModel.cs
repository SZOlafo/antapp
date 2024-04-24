using antapp.Chat.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace antapp.Chat.ViewModels
{
    public class ChatListViewModel
    {
        public required List<ChatDto> Chats {  get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using antapp.Shared.Auth.DbConnection.Tables;
using antapp.Shared.Auth.Dtos;

namespace antapp.Chat.ViewModels
{
    public class ChatViewModel
    {
        public required ChatDto Chat {  get; set; }
        public required List<ChatEntryDto> Entries { get; set; }
    }
}

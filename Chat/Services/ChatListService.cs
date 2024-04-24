using antapp.Chat.Models;
using antapp.Shared.Auth.DbConnection;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace antapp.Chat.Services
{
    public interface IChatListService
    {
        Task<List<ChatDto>> GetChat();
    }
    internal class ChatListService : IChatListService
    {
        private readonly antappDbContext _dbContext;

        public ChatListService(antappDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<ChatDto>> GetChat()
        {
            return await _dbContext.Chats
                .Select(x => new ChatDto
                {
                    Id = x.id,
                    Description = x.description,
                    Chatname = x.chatname,
                    Location = x.Location,
                }).ToListAsync();
        }
    }
}

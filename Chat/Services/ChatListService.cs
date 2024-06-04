using antapp.Chat.Models;
using antapp.Shared.Auth.DbConnection;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace antapp.Chat.Services;

public interface IChatListService
{
    Task<List<ChatDto>> GetChat(string userId);
}
internal class ChatListService : IChatListService
{
    private readonly antappDbContext _dbContext;

    public ChatListService(antappDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<List<ChatDto>> GetChat(string userId)
    {
        var chats = await _dbContext.Chats
            .Select(x => new ChatDto
            {
                Id = x.id,
                Description = x.description,
                Chatname = x.chatname,
                Location = x.Location,
            })
            .OrderBy(x => x.Id)
            .ToListAsync();
        var cathes = _dbContext.UserAnts.Where(x => x.userid == userId).ToList();
        foreach(var chat in  chats)
        {
            decimal count = (decimal)cathes.Where(x => x.Location.id == chat.Location.id).Count() / 5 * 100;
            chat.CatchCount = (int)count;
        }
        return chats;
    }
}

using antapp.Shared.Auth;
using antapp.Shared.Auth.DbConnection;
using antapp.Shared.Auth.DbConnection.Tables;
using antapp.Shared.Auth.Dtos;
using Microsoft.EntityFrameworkCore;

namespace antapp.Chat.Services;

public interface IChatService
{
    Task<ChatDto?> GetChat(int chatId);
    Task<List<ChatEntryDto>> GetChatEntries(int chatId);
    Task DeleteChatEntry(int entryId);
    Task EditChatEntry(ChatEntryDto entry, string user);
    Task AddChatEntry(ChatEntryDto entryId, string user);
}

internal class ChatService : IChatService
{
    private readonly antappDbContext _dbContext;


    public ChatService(antappDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<ChatDto?> GetChat(int chatId)
    {
        return await _dbContext.Chats
            .Where(c => c.id == chatId)
            .Select(x => new ChatDto
            {
                Id = x.id,
                Description = x.description,
                Chatname = x.chatname,
                LocationId = x.locationid.Id,
            }).FirstOrDefaultAsync();
    }

    public async Task<List<ChatEntryDto>> GetChatEntries(int chatId)
    {
        return await _dbContext.ChatEntries
            .Where(e => e.chatId == chatId)
            .OrderBy(e => e.EntryDate)
            .Select(x => new ChatEntryDto
            {
                Id = x.id,
                message = x.message,
                messageVisibility = x.messagevisibility,
                EntryDate = x.EntryDate,
                chatId = x.chatId,
                userId = x.userId
            }).ToListAsync();
    }

    public async Task DeleteChatEntry(int entryId)
    {
        var entry = await _dbContext.ChatEntries.Where(e => e.id == entryId).FirstAsync();
        if(entry is not null)
        {
            _dbContext.ChatEntries.Remove(entry);
            await _dbContext.SaveChangesAsync();
        }
    }

    public async Task AddChatEntry(ChatEntryDto entry, string user)
    {
        if(entry is not null)
        {
            var newEntry = new ChatEntryTable
            {
                message = entry.message,
                messagevisibility = entry.messageVisibility,
                EntryDate = entry.EntryDate,
                chatId = entry.chatId,
                userId = user,
            };
            await _dbContext.ChatEntries.AddAsync(newEntry);
            await _dbContext.SaveChangesAsync();
        }
    }

    public async Task EditChatEntry(ChatEntryDto entry, string user)
    {
        var toEdit = await _dbContext.ChatEntries.Where(x => x.id == entry.Id).FirstOrDefaultAsync();
        if(toEdit is not null)
        {
            toEdit.message = entry.message;
            await _dbContext.SaveChangesAsync();
        }
    }
}


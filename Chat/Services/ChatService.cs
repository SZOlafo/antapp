using antapp.Chat.Models;
using antapp.Shared.Auth;
using antapp.Shared.Auth.DbConnection;
using antapp.Shared.Auth.DbConnection.Tables;
using antapp.Shared.Auth.Dtos;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace antapp.Chat.Services;

public interface IChatService
{
    Task<ChatDto?> GetChat(int chatId);
    Task<List<ChatEntryDto>> GetChatEntries(int chatId);
    Task DeleteChatEntry(int entryId);
    Task EditChatEntry(ChatEntryDto entry, string user);
    Task AddChatEntry(ChatEntryDto entryId, string user);

    Task<String> GetUserName(string userd);

}

internal class ChatService : IChatService
{
    private readonly antappDbContext _dbContext;
    private readonly UserManager<User> _userManager;


    public ChatService(antappDbContext dbContext, UserManager<User> userManager)
    {
        _dbContext = dbContext;
        _userManager = userManager;
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
                Location = x.Location,
            }).FirstOrDefaultAsync();
    }

    public async Task<List<ChatEntryDto>> GetChatEntries(int chatId)
    {
        return await _dbContext.ChatEntries
            .Where(e => e.chatid == chatId)
            .OrderBy(e => e.entrydate)
            .Select(x => new ChatEntryDto
            {
                Id = x.id,
                message = x.message,
                messageVisibility = x.messagevisibility,
                EntryDate = x.entrydate,
                chatId = x.chatid,
                userId = x.User.UserName
            }).ToListAsync();

        //foreach(var entry in entries)
        //{
        //    entry.userId = await GetUserName(entry.userId);
        //}
        //return entries;
    }

    public async Task DeleteChatEntry(int entryId)
    {
        var entry = await _dbContext.ChatEntries.Where(e => e.id == entryId).FirstAsync();
        if(entry is not null)
        {
            _dbContext.ChatEntries.Remove(entry);
            await _dbContext.SaveChangesAsync();
        }
        //await _dbContext.ChatEntries.Where(e => e.id == entryId).ExecuteDeleteAsync();
    }

    public async Task AddChatEntry(ChatEntryDto entry, string user)
    {
        if(entry is not null)
        {
            var newEntry = new ChatEntryTable
            {
                message = entry.message,
                messagevisibility = entry.messageVisibility,
                entrydate = entry.EntryDate,
                chatid = entry.chatId,
                userid = user,
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
        //await _dbContext.ChatEntries.Where(x => x.id == entry.Id).ExecuteUpdateAsync(x => x.SetProperty(y => y.message, entry.message));
    }

    public async Task<string> GetUserName(string userId)
    {
        var user = await _userManager.FindByIdAsync(userId);
        var userName = user.UserName;
        return userName;
    }
}


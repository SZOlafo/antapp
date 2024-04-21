using antapp.Shared.Auth.DbConnection;
using antapp.Shared.Auth.DbConnection.Tables;
using antapp.Shared.Auth.Dtos;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace antapp.Chat.Services
{
    public interface IChatService
    {
        Task<ChatDto?> GetChat(int chatId);
        Task<List<ChatEntryDto>> GetChatEntries(int chatId);
        Task DeleteChatEntry(int entryId);
        Task EditChatEntry(ChatEntryDto entry);
        Task AddChatEntry(ChatEntryDto entryId);
    }
    internal class ChatService : IChatService
    {
        private readonly antappDbContext _dbContext;

        public async Task<ChatDto?> GetChat(int chatId)
        {
            return await _dbContext.Chats
                .Where(c => c.Id == chatId)
                .Select(x => new ChatDto
                {
                    Id = x.Id,
                    Description = x.Description,
                    Chatname = x.ChatName,
                    LocationId = x.LocationId
                }).FirstOrDefaultAsync();
        }

        public async Task<List<ChatEntryDto>> GetChatEntries(int chatId)
        {
            return await _dbContext.ChatEntries
                .Where(e => e.chatId == chatId)
                .OrderBy(e => e.EntryDate)
                .Select(x => new ChatEntryDto
                {
                    id = x.id,
                    message = x.message,
                    messageVisibility = x.messageVisibility,
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

        public async Task AddChatEntry(ChatEntryDto entry)
        {
            if(entry is not null)
            {
                var newEntry = new ChatEntryTable
                {
                    message = entry.message,
                    messageVisibility = entry.messageVisibility,
                    EntryDate = entry.EntryDate,
                    chatId = entry.chatId,
                    userId = entry.userId,
                };
                await _dbContext.ChatEntries.AddAsync(newEntry);
                _dbContext.SaveChangesAsync();
            }
        }

        public async Task EditChatEntry(ChatEntryDto entry)
        {
            var toEdit = await _dbContext.ChatEntries.Where(x => x.id == entry.id).FirstOrDefaultAsync();
            if(toEdit is not null)
            {
                toEdit.message = entry.message;
                await _dbContext.SaveChangesAsync();
            }
        }
    }
    
}

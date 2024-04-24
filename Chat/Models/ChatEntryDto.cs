namespace antapp.Chat.Models;

public class ChatEntryDto
{
    public required int Id { get; set; }
    public required string message { get; set; }
    public required bool messageVisibility { get; set; }
    public required DateOnly EntryDate { get; set; }
    public required int chatId { get; set; }
    public required string userId { get; set; }
}

namespace antapp.Chat.Models;

public class ChatEntryDto
{
    public required int Id { get; set; }
    public required string Message { get; set; }
    public required bool MessageVisibility { get; set; }
    public required DateOnly EntryDate { get; set; }
    public required int ChatId { get; set; }
    public required string UserId { get; set; }
}

using antapp.Shared.Auth.DbConnection.Tables;

namespace antapp.Chat.Models;

public class ChatDto
{
    public required int Id { get; set; }
    public required string Chatname { get; set; }
    public required string Description { get; set; }
    public required LocationTable Location { get; set; }
    public int? CatchCount { get; set; }
}

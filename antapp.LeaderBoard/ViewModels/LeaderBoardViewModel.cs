using antapp.LeaderBoard.Models;

namespace antapp.LeaderBoard.ViewModels;

public class LeaderBoardViewModel
{
    public required List<UserDto> Users { get; set; }
}

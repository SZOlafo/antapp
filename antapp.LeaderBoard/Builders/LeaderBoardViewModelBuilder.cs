using antapp.LeaderBoard.Services;
using antapp.LeaderBoard.ViewModels;

namespace antapp.LeaderBoard.Builders;

public interface ILeaderBoardViewModelBuilder
{
    public Task<LeaderBoardViewModel> Build();
}

internal class LeaderBoardViewModelBuilder : ILeaderBoardViewModelBuilder
{
    private readonly ILeaderBoardService _leaderBoardService;

    public LeaderBoardViewModelBuilder(ILeaderBoardService leaderBoardService)
    {
        _leaderBoardService = leaderBoardService;
    }

    public async Task<LeaderBoardViewModel> Build()
    {
        return new LeaderBoardViewModel 
        { 
            Users = await _leaderBoardService.GetUsers() 
        };
    }
}

using antapp.LeaderBoard.Models;
using antapp.Shared.Auth.DbConnection;
using Microsoft.EntityFrameworkCore;

namespace antapp.LeaderBoard.Services;

internal interface ILeaderBoardService
{
    public Task<List<UserDto>> GetUsers();
}

internal class LeaderBoardService : ILeaderBoardService
{
    private readonly antappDbContext _dbContext;

    public LeaderBoardService(antappDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<List<UserDto>> GetUsers()
    {
        var users = await _dbContext.Users
            .Select(x => new UserIdName 
            { 
                UserId = x.Id, 
                UserName = x.UserName
            })
            .ToListAsync();
        var catches = await _dbContext.UserAnts
            .Select(x => x.userid)
            .ToListAsync();
        List<UserDto> Leaderboard = new List<UserDto>();
        foreach(var user in users)
        {
            var points = catches.Where(x => x == user.UserId).Count();
            var position = new UserDto
            {
                UserName = user.UserName,
                Score = points
            };
            Leaderboard.Add(position);
        }
        return [.. Leaderboard.OrderByDescending(x => x.Score)];
    }
}

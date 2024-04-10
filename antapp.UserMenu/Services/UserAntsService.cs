using antapp.Shared.Auth.DbConnection;
using antapp.UserMenu.Models;
using Microsoft.EntityFrameworkCore;
using System.Data.Common;

namespace antapp.UserMenu.Services;


public interface IUserAntsService
{
    Task<List<UserAnt>> GetUserAnts(string userId);
}

internal class UserAntService : IUserAntsService
{
    private readonly antappDbContext _db;

    public UserAntService(antappDbContext db)
    {
        _db = db;
    }

    public async Task<List<UserAnt>> GetUserAnts(string userId)
    {
        return await _db.UserAnts
            .Where(x => x.UserId == userId)
            .Select(x => new UserAnt
            {
                Id = x.Ant.Id,
                Name = x.Ant.AntName,
                Description = x.Ant.Description,
                ImageUrl = x.Ant.ImageUrl,
                CatchDate = x.CathDate,
                CatchLocation = x.Location.LocationName
            })
            .ToListAsync();
    }
}


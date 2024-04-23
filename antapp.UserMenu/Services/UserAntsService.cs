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
            .Where(x => x.userid == userId)
            .Select(x => new UserAnt
            {
                Id = x.Ants.id,
                Name = x.Ants.antname,
                Description = x.Ants.description,
                ImageUrl = x.Ants.imageurl,
                CatchDate = x.catchdate,
                CatchLocation = x.Location.locationname
            })
            .ToListAsync();
    }
}


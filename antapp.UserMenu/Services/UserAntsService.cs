using antapp.Shared.Auth;
using antapp.Shared.Auth.DbConnection;
using antapp.UserMenu.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Data.Common;

namespace antapp.UserMenu.Services;


public interface IUserAntsService
{
    Task<List<UserAnt>> GetUserAnts(string userId);
    Task<List<UserAchivment>> GetUserAchivments(string userId);
}

internal class UserAntService : IUserAntsService
{
    private readonly antappDbContext _db;
    private readonly UserManager<User> _userManager;

    public UserAntService(antappDbContext db, UserManager<User> userManager)
    {
        _db = db;
        _userManager = userManager;
    }

    public async Task<string> GetUserName(string userId)
    {
        var user = await _userManager.FindByIdAsync(userId);
        var userName = user.UserName;
        return userName;
    }

    public async Task<List<UserAnt>> GetUserAnts(string userId)
    {
        var userName = GetUserName("9eb1f47a-d5f1-43d9-b5bc-74e91b5fda99");
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

    public async Task<List<UserAchivment>> GetUserAchivments(string userId)
    {
        return await _db.UserAchivments
            .Where(x => x.userid == userId)
            .Select(a => new UserAchivment
            {
                Id = a.Achivment.id,
                Name = a.Achivment.achivmentname,
                Description = a.Achivment.description,
                AquireDate = a.aquiredate,
                ImageUrl = a.Achivment.imageurl,
                Requirement = a.Achivment.requirement,
                Proggress = a.progress
            })
            .ToListAsync();
    }
}


using antapp.Shared.Auth;
using antapp.Shared.Auth.DbConnection;
using antapp.Shared.Auth.DbConnection.Tables;
using antapp.UserMenu.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Data.Common;

namespace antapp.UserMenu.Services;


public interface IUserAntsService
{
    Task<List<UserAnt>> GetUserAnts(string userId);
    Task<List<UserAchivment>> GetUserAchivments(string userId);
    Task UpdateAchivments(string userId);
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
        return await _db.UserAnts
            .Where(x => x.userid == userId)
            .OrderByDescending(o => o.catchdate)
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
        await UpdateAchivments(userId);
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

    public async Task UpdateAchivments(string userId)
    {
        var achivments = await _db.Achivments.ToListAsync();
        var userAchivs = await _db.UserAchivments.Where(x => x.userid == userId).Select(x => x.Achivment.id).ToListAsync();
        var userAnts = await _db.UserAnts.Where(x => x.userid == userId).ToListAsync();
        foreach(var achievement in achivments) 
        {
            if (userAchivs.Contains(achievement.id)) 
            {
                continue;
            }
            var achivType = achievement.requirement.Split(";");
            switch (achivType[0])
            {
                case "Catch":
                    var req = achivType[2].Split(",");
                    switch (req[0])
                    { 
                        case "A":
                            if (req[1] == "0")
                            {
                                var count = userAnts.Count();
                                if(count >= Int32.Parse(achivType[1]))
                                {
                                    var newAchivment = new UserAchivmentTable
                                    {
                                        userid = userId,
                                        Achivment = achievement,
                                        aquiredate = DateOnly.FromDateTime(DateTime.Now),
                                        progress = "Completed"
                                    };
                                    await _db.UserAchivments.AddAsync(newAchivment);
                                    await _db.SaveChangesAsync();
                                }
                            }
                            else
                            {
                                var ant = Int32.Parse(req[1]);
                                var count = userAnts.Where(x => x.Ants.id == ant).Count();
                                if (count >= Int32.Parse(achivType[1]))
                                {
                                    var newAchivment = new UserAchivmentTable
                                    {
                                        userid = userId,
                                        Achivment = achievement,
                                        aquiredate = DateOnly.FromDateTime(DateTime.Now),
                                        progress = "Completed"
                                    };
                                    await _db.UserAchivments.AddAsync(newAchivment);
                                    await _db.SaveChangesAsync();
                                }
                            }
                            break;

                        case "L":
                            if (req[1] == "0")
                            {
                                var count = userAnts.Count();
                                if (count >= Int32.Parse(achivType[1]))
                                {
                                    var newAchivment = new UserAchivmentTable
                                    {
                                        userid = userId,
                                        Achivment = achievement,
                                        aquiredate = DateOnly.FromDateTime(DateTime.Now),
                                        progress = "Completed"
                                    };
                                    await _db.UserAchivments.AddAsync(newAchivment);
                                    await _db.SaveChangesAsync();
                                }
                            }
                            else
                            {
                                var loc = Int32.Parse(req[1]);
                                var count = userAnts.Where(x => x.Location.id == loc).Count();
                                if (count >= Int32.Parse(achivType[1]))
                                {
                                    var newAchivment = new UserAchivmentTable
                                    {
                                        userid = userId,
                                        Achivment = achievement,
                                        aquiredate = DateOnly.FromDateTime(DateTime.Now),
                                        progress = "Completed"
                                    };
                                    await _db.UserAchivments.AddAsync(newAchivment);
                                    await _db.SaveChangesAsync();
                                }
                            }
                            break;
                        default: 
                            break;
                    }
                    break;

                default:
                    break;
            }
        }
    }
}


using antapp.GameMap.Models;
using antapp.Shared.Auth.DbConnection;
using antapp.Shared.Auth.DbConnection.Tables;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration.UserSecrets;

namespace antapp.GameMap.Services;

public interface IGameMapService
{
    Task<List<Location>> getLocations();
    Task<Location> getLocation(int locationId);
    Task<Ant> getRandomAnt();

    Task CathAnt(string userId, int locationId, int antId);
}

internal class GameMapService : IGameMapService
{
    private readonly antappDbContext _antappDbContext;

    public GameMapService(antappDbContext antappDbContext)
    {
        _antappDbContext = antappDbContext;
    }

    public async Task CathAnt(string userId, int locationId, int antId)
    {
        var ant = await _antappDbContext.Ants.Where(x => x.id == antId).FirstOrDefaultAsync();
        var location = await _antappDbContext.Locations.Where(x => x.id ==  locationId).FirstOrDefaultAsync();
        if((ant is null) || (location is null)) 
        {
            return;
        }
        var newCath = new UserAntTable
        {
            userid = userId,
            Location = location,
            Ants = ant,
            catchdate = DateTime.UtcNow,
        };
        await _antappDbContext.UserAnts.AddAsync(newCath);
        await _antappDbContext.SaveChangesAsync();
    }

    public async Task<Location> getLocation(int locationId)
    {
        
        var location = await _antappDbContext.Locations.Where(l => l.id == locationId).Select(x => new Location
        {
            Id = x.id,
            Name = x.locationname,
            Coordinates = x.coordinates,
            Range = x.range
        }).FirstOrDefaultAsync();
        if(location is not null)
        {
            return location;
        }
        else
        {
            throw new Exception();
        }
    }

    public async Task<List<Location>> getLocations()
    {
        return await _antappDbContext.Locations.Select(x => new Location
        {
            Id= x.id,
            Name = x.locationname,
            Coordinates = x.coordinates,
            Range = x.range,
        }).ToListAsync();
    }

    public async Task<Ant> getRandomAnt()
    {
        var randomAnt = await _antappDbContext.Ants.OrderBy(r => EF.Functions.Random()).Select(x => new Ant
        {
            Id = x.id,
            Name = x.antname,
            ImageUrl = x.imageurl
        }).FirstOrDefaultAsync();
        if (randomAnt is not null)
        {
            return randomAnt;
        }
        else
        {
            throw new Exception();
        }
    }
}

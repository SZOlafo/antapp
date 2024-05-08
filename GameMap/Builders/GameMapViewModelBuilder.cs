using antapp.GameMap.Models;
using antapp.GameMap.Services;
using antapp.GameMap.ViewModels;
using System;
using System.Collections.Concurrent;
using System.Globalization;

namespace antapp.GameMap.Builders;

public interface IGameMapViewModelBuilder
{
    Task<GameMapViewModel> Build(int locationId);
}

internal class GameMapViewModelBuilder : IGameMapViewModelBuilder
{
    private readonly IGameMapService _gameMapService;
    private readonly Random _random;

    public GameMapViewModelBuilder(IGameMapService gameMapService, Random random)
    {
        _gameMapService = gameMapService;
        _random = random;
    }

    public async Task<GameMapViewModel> Build(int locationId)
    {
        var location = await _gameMapService.getLocation(locationId);
        var antCount = _random.Next(2, 5);
        List<Ant> ants = new List<Ant>();
        List<AntLocation> antLocations = new List<AntLocation>();
        for(int i=0; i< antCount; i++)
        {
            ants.Add(await _gameMapService.getRandomAnt());
        }
        foreach(var ant in ants)
        {
            var longitude = decimal.Parse(location.Coordinates.Split(",")[0], CultureInfo.InvariantCulture);
            var lattitude = decimal.Parse(location.Coordinates.Split(",")[1], CultureInfo.InvariantCulture);
            var rRange = location.Range / 100000m;
            longitude += RandomNumberBetween(-rRange, rRange);
            lattitude += RandomNumberBetween(-rRange, rRange);
            
            antLocations.Add(new AntLocation
            {
                Ant = ant,
                Coordinates = longitude.ToString(CultureInfo.InvariantCulture) + "," + lattitude.ToString(CultureInfo.InvariantCulture)
            });
        }
        return new GameMapViewModel
        {
            Location = location,
            LocationList = await _gameMapService.getLocations(),
            AntLocations = antLocations,
            AntCount = antCount
        };
    }

    private decimal RandomNumberBetween(decimal minValue, decimal maxValue)
    {
        var next = new decimal(_random.NextDouble());

        return minValue + (next * (maxValue - minValue));
    }
}

using antapp.GameMap.Models;
using System.Text.Json;

namespace antapp.GameMap.ViewModels;

public class GameMapViewModel
{
    public required Location Location { get; set; }
    public required List<AntLocation> AntLocations { get; set; }
    public required List<Location> LocationList { get; set; }
    public required int AntCount { get; set; }
}

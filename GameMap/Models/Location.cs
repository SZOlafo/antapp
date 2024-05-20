namespace antapp.GameMap.Models;

public class Location
{
    public required int Id { get; set; }
    public required string Name { get; set; }
    public required string Coordinates { get; set; }
    public required int Range { get; set; }
}

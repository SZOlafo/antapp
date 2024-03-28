namespace antapp.UserMenu.Models;

public class Ant
{
    public required int Id { get; set; }
    public required string Name { get; set; }
    public required string Description { get; set; }
    public required DateTime CatchDate { get; set; }
    public required string CatchLocation { get; set; }
    public required string ImageUrl { get; set; }
}

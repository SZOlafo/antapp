namespace antapp.UserMenu.Models;

public class Achivment
{
    public required int Id { get; set; }
    public required string Name { get; set; }
    public required string Description { get; set; }
    public required int Requirement { get; set; }
    public required int Proggress { get; set; }
    public required string ImageUrl { get; set; }
    public DateTime AquireDate { get; set; }
}

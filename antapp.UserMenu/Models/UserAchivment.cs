namespace antapp.UserMenu.Models;

public class UserAchivment
{
    public required int Id { get; set; }
    public required string Name { get; set; }
    public required string Description { get; set; }
    public required string Requirement { get; set; }
    public required string Proggress { get; set; }
    public required string ImageUrl { get; set; }
    public required DateOnly AquireDate { get; set; }
}

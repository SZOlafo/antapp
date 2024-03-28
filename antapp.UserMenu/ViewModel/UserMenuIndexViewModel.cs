using antapp.UserMenu.Models;

namespace antapp.UserMenu.ViewModel;

public class UserMenuIndexViewModel
{
    public required string UserName { get; set; }
    public required List<Ant> AntCollection { get; set; }
    public required List<Achivment> Achivments { get; set; }
}

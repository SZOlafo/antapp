using antapp.UserMenu.Models;

namespace antapp.UserMenu.ViewModel;

public class UserMenuIndexViewModel
{
    public required string UserName { get; set; }
    public required List<UserAnt> AntCollection { get; set; }
    public required List<UserAchivment> Achivments { get; set; }
}

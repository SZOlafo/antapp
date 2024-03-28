using antapp.Shared.Auth;
using antapp.UserMenu.Models;
using antapp.UserMenu.ViewModel;

namespace antapp.UserMenu.Builders;

public interface IUserMenuViewModelBuilder
{
    Task<UserMenuIndexViewModel> Build();
}

internal class UserMenuViewModelBuilder : IUserMenuViewModelBuilder
{
    private readonly IUserAccesor _userAccesor;

    public UserMenuViewModelBuilder(IUserAccesor userAccesor)
    {
        _userAccesor = userAccesor;
    }

    public async Task<UserMenuIndexViewModel> Build()
    {
        return new UserMenuIndexViewModel
        {
            UserName = _userAccesor.Login,
            AntCollection = new List<Ant>(),
            Achivments = new List<Achivment>()
        };
    }
}

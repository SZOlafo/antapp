using antapp.Shared.Auth;
using antapp.UserMenu.Models;
using antapp.UserMenu.Services;
using antapp.UserMenu.ViewModel;
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;

namespace antapp.UserMenu.Builders;

public interface IUserMenuViewModelBuilder
{
    Task<UserMenuIndexViewModel> Build(string userName, string userId);
}

internal class UserMenuViewModelBuilder : IUserMenuViewModelBuilder
{
    private readonly IUserAntsService _userAntsService;

    public UserMenuViewModelBuilder(IUserAntsService userAntsService)
    {
        _userAntsService = userAntsService;
    }

    public async Task<UserMenuIndexViewModel> Build(string userName, string userId)
    {
        return new UserMenuIndexViewModel
        {
            UserName = userName,
            AntCollection = await _userAntsService.GetUserAnts(userId),
            Achivments = new List<UserAchivment>()
        };
    }
}

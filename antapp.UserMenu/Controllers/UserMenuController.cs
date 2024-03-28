using antapp.UserMenu.Builders;
using Microsoft.AspNetCore.Mvc;
namespace antapp.UserMenu.Controllers;

public class UserMenuController : Controller
{
    IUserMenuViewModelBuilder _modelBuilder;

    public UserMenuController(IUserMenuViewModelBuilder modelBuilder)
    {
        _modelBuilder = modelBuilder;
    }

    public async Task<IActionResult> Index() 
    {
        var vievModel = await _modelBuilder.Build();
        return View(vievModel); 
    }
}

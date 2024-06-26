﻿using antapp.Shared.Auth;
using antapp.UserMenu.Builders;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
namespace antapp.UserMenu.Controllers;

[Authorize]
public class UserMenuController : Controller
{
    IUserMenuViewModelBuilder _modelBuilder;

    public UserMenuController(IUserMenuViewModelBuilder modelBuilder)
    {
        _modelBuilder = modelBuilder;
    }

    [HttpGet]
    //[Route("[Controller]/[Action]")]
    public async Task<IActionResult> Index() 
    {
        string userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
        string userName = User.Identity.Name;

        if (userId == null)
        {
            userId = "No User";
        }
        var vievModel = await _modelBuilder.Build(userName, userId);
        return View(vievModel); 
    }
}

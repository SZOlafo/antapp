using antapp.GameMap.Builders;
using antapp.GameMap.Models;
using antapp.GameMap.Services;
using antapp.Shared.Auth.Dtos;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace antapp.GameMap.Controllers;

public class GameMapController : Controller
{
    private readonly IGameMapViewModelBuilder _gameMapViewModelBuilder;
    private readonly IGameMapService _gameMapService;

    public GameMapController(IGameMapViewModelBuilder gameMapViewModelBuilder, IGameMapService gameMapService)
    {
        _gameMapViewModelBuilder = gameMapViewModelBuilder;
        _gameMapService = gameMapService;
    }

    [HttpGet]
    //[Route("[Controller]/[Action]")]
    public async Task<IActionResult> Index([FromQuery] int locationId)
    {
        var view = await _gameMapViewModelBuilder.Build(locationId);
        return View(view);
    }

    [HttpPost]
    //[Route("[Controller]/[Action]")]
    public async Task<IActionResult> Catch([FromBody] CatchRequest request)
    {
        string? userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
        if(userId is null) {
            return Json(new { success = false });
        }
        await _gameMapService.CathAnt(userId, request.LocationId, request.AntId);
        return Json(new { success = true });
    }
}

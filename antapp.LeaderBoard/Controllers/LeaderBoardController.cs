using antapp.LeaderBoard.Builders;
using Microsoft.AspNetCore.Mvc;

namespace antapp.LeaderBoard.Controllers;


public class LeaderBoardController : Controller
{
    private readonly ILeaderBoardViewModelBuilder _builder;

    public LeaderBoardController(ILeaderBoardViewModelBuilder builder)
    {
        _builder = builder;
    }

    public async Task<IActionResult> Index()
    {
        var view = await _builder.Build();
        return View(view);
    }
}

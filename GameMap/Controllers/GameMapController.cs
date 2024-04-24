using Microsoft.AspNetCore.Mvc;

namespace antapp.GameMap.Controllers;

public class GameMapController : Controller
{
    public IActionResult Index()
    {
        return View();
    }

}

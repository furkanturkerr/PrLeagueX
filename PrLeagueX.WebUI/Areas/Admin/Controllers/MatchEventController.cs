using Microsoft.AspNetCore.Mvc;

namespace PrLeagueX.WebUI.Areas.Admin.Controllers;

[Area("Admin")]
public class MatchEventController : Controller
{
    [HttpGet]
    public IActionResult Manage(int id)
    {
        ViewBag.MatchId = id;
        return View();
    }
}
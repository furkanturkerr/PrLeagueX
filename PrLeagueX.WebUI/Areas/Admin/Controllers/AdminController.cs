using Microsoft.AspNetCore.Mvc;

namespace PrLeagueX.WebUI.Areas.Admin.Controllers;

public class AdminController : Controller
{
    // GET
    public IActionResult Index()
    {
        return View();
    }
}
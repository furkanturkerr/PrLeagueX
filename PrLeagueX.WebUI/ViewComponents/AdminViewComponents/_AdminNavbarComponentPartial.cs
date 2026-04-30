using Microsoft.AspNetCore.Mvc;

namespace PrLeagueX.WebUI.ViewComponents.AdminViewComponents;

public class _AdminNavbarComponentPartial : ViewComponent
{
    public IViewComponentResult Invoke() => View();
}
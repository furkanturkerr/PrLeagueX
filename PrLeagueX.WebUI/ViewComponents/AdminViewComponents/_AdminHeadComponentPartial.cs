using Microsoft.AspNetCore.Mvc;

namespace PrLeagueX.WebUI.ViewComponents.AdminViewComponents;

public class _AdminHeadComponentPartial : ViewComponent
{
    public IViewComponentResult Invoke()
    {
        return View();
    }
}
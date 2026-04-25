using Microsoft.AspNetCore.Mvc;

namespace PrLeagueX.WebUI.ViewComponents.DefaultViewComponents;

public class _DefaultNavbarComponentPartial : ViewComponent
{
    public IViewComponentResult Invoke()
    {
        return View();
    }
}
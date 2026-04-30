using Microsoft.AspNetCore.Mvc;

namespace PrLeagueX.WebUI.ViewComponents.AdminViewComponents;

public class _AdminHeaderComponentPartial : ViewComponent
{
    public IViewComponentResult Invoke() => View();
}
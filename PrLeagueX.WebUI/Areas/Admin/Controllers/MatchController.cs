using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;
using PrLeagueX.DtoLayer.MatchDtos;
using PrLeagueX.DtoLayer.SeasonDtos;
using PrLeagueX.WebUI.Areas.Admin.Models;

namespace PrLeagueX.WebUI.Areas.Admin.Controllers;
[Area("Admin")]
public class MatchController : Controller
{
    private readonly IHttpClientFactory _httpClientFactory;

    public MatchController(IHttpClientFactory httpClientFactory)
    {
        _httpClientFactory = httpClientFactory;
    }

    // GET
    public async Task<IActionResult> Index(int? seasonId, int? week)
    {
        var client = _httpClientFactory.CreateClient();
        
        var seasons = new List<ResultSeasonDto>();
        var seasonResponse = await client.GetAsync("http://localhost:5164/api/Season");
        if (seasonResponse.IsSuccessStatusCode)
        {
            var seasonJson = await seasonResponse.Content.ReadAsStringAsync();
            seasons = JsonConvert.DeserializeObject<List<ResultSeasonDto>>(seasonJson);

            ViewBag.Seasons = new SelectList(seasons, "SeasonId", "SeasonName");
        }
        
        var selectedSeasonId = seasonId
                               ?? seasons.FirstOrDefault(x => x.IsActive)?.SeasonId
                               ?? 1;
        
        var selectWeek = week ?? 1;

        var match = new List<ResultMatchDto>();
        var response = await client.GetAsync($"http://localhost:5164/api/Match/season/{selectedSeasonId}/week/{selectWeek}");
        if (response.IsSuccessStatusCode)
        {
            var jsonData = await response.Content.ReadAsStringAsync();
            match = JsonConvert.DeserializeObject<List<ResultMatchDto>>(jsonData);
        }

        var model = new MatchListViewModel
        {
            Matches = match,
            Seasons = seasons,
            SelectedSeasonId = selectedSeasonId,
            SelectedWeek = selectWeek
        };
        
        return View(model);
    }
}
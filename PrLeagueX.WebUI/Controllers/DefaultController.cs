using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using PrLeagueX.DtoLayer.MatchDtos;
using PrLeagueX.DtoLayer.SeasonDtos;
using PrLeagueX.WebUI.Models;

namespace PrLeagueX.WebUI.Controllers;

public class DefaultController : Controller
{
    private readonly IHttpClientFactory _httpClientFactory;

    public DefaultController(IHttpClientFactory httpClientFactory)
    {
        _httpClientFactory = httpClientFactory;
    }

    public async Task<IActionResult> Index(int? seasonId, int? week)
    {
        var client = _httpClientFactory.CreateClient();

        var seasons = new List<ResultSeasonDto>();

        var seasonResponse = await client.GetAsync("http://localhost:5164/api/Season");

        if (seasonResponse.IsSuccessStatusCode)
        {
            var seasonJson = await seasonResponse.Content.ReadAsStringAsync();
            seasons = JsonConvert.DeserializeObject<List<ResultSeasonDto>>(seasonJson)
                      ?? new List<ResultSeasonDto>();
        }

        // Aktif sezonu seç
        var selectedSeasonId = seasonId
                               ?? seasons.FirstOrDefault(x => x.IsActive)?.SeasonId
                               ?? 6;

        // Sitede anlık tarih takip edilmiyor manuel veri : 
        var selectedWeek = week ?? 3;

        var matches = new List<ResultMatchCardDto>();

        var matchResponse = await client.GetAsync(
            $"http://localhost:5164/api/DefaultMatches/season/{selectedSeasonId}/week/{selectedWeek}");

        if (matchResponse.IsSuccessStatusCode)
        {
            var matchJson = await matchResponse.Content.ReadAsStringAsync();
            matches = JsonConvert.DeserializeObject<List<ResultMatchCardDto>>(matchJson)
                      ?? new List<ResultMatchCardDto>();
        }

        var model = new DefaultMatchPageViewModel
        {
            Matches = matches,
            Seasons = seasons,
            SelectedSeasonId = selectedSeasonId,
            SelectedWeek = selectedWeek,

            LiveCount = matches.Count(x => x.Status == 1),
            FinishedCount = matches.Count(x => x.Status == 2),
            UpcomingCount = matches.Count(x => x.Status == 0),

            //Listedeki ilk maçı alır
            FeaturedMatch = matches.FirstOrDefault()
        };

        return View(model);
    }
}
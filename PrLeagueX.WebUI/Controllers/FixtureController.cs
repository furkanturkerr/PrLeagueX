using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using PrLeagueX.DtoLayer.MatchDtos;
using PrLeagueX.DtoLayer.SeasonDtos;
using PrLeagueX.WebUI.Models;

namespace PrLeagueX.WebUI.Controllers;

public class FixtureController : Controller
{
    private readonly IHttpClientFactory _httpClientFactory;

    public FixtureController(IHttpClientFactory httpClientFactory)
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

        var selectedSeasonId = seasonId
                               ?? seasons.FirstOrDefault(x => x.IsActive)?.SeasonId
                               ?? 2;

        var selectedWeek = week ?? 1;

        var fixtures = new List<ResultFixtureDto>();

        var fixtureResponse = await client.GetAsync(
            $"http://localhost:5164/api/Fixture/season/{selectedSeasonId}/week/{selectedWeek}");

        if (fixtureResponse.IsSuccessStatusCode)
        {
            var fixtureJson = await fixtureResponse.Content.ReadAsStringAsync();
            fixtures = JsonConvert.DeserializeObject<List<ResultFixtureDto>>(fixtureJson)
                       ?? new List<ResultFixtureDto>();
        }

        var model = new FixturePageViewModel
        {
            Fixtures = fixtures,
            Seasons = seasons,
            SelectedSeasonId = selectedSeasonId,
            SelectedWeek = selectedWeek,
            TotalWeeks = 38
        };

        return View(model);
    }
}
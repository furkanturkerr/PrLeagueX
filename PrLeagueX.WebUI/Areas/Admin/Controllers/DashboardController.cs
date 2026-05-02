using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using PrLeagueX.DtoLayer.MatchDetailDtos;
using PrLeagueX.DtoLayer.MatchDtos;
using PrLeagueX.DtoLayer.TeamDtos;
using PrLeagueX.WebUI.Areas.Admin.Models;

namespace PrLeagueX.WebUI.Areas.Admin.Controllers;

[Area("Admin")]
public class DashboardController : Controller
{
    private readonly IHttpClientFactory _httpClientFactory;

    public DashboardController(IHttpClientFactory httpClientFactory)
    {
        _httpClientFactory = httpClientFactory;
    }

    public async Task<IActionResult> Index()
    {
        var client = _httpClientFactory.CreateClient();

        var matches = new List<ResultMatchDto>();
        var details = new List<ResultMatchDetailDto>();
        var teams = new List<ResultTeamDto>();

        var matchResponse = await client.GetAsync("http://localhost:5164/api/Match");

        if (matchResponse.IsSuccessStatusCode)
        {
            var json = await matchResponse.Content.ReadAsStringAsync();
            matches = JsonConvert.DeserializeObject<List<ResultMatchDto>>(json)
                      ?? new List<ResultMatchDto>();
        }

        var detailResponse = await client.GetAsync("http://localhost:5164/api/MatchDetails");

        if (detailResponse.IsSuccessStatusCode)
        {
            var json = await detailResponse.Content.ReadAsStringAsync();
            details = JsonConvert.DeserializeObject<List<ResultMatchDetailDto>>(json)
                      ?? new List<ResultMatchDetailDto>();
        }

        var teamResponse = await client.GetAsync("http://localhost:5164/api/Teams");

        if (teamResponse.IsSuccessStatusCode)
        {
            var json = await teamResponse.Content.ReadAsStringAsync();
            teams = JsonConvert.DeserializeObject<List<ResultTeamDto>>(json)
                    ?? new List<ResultTeamDto>();
        }

        // Projede maç tarihleri seed olduğu için bugünün maçları yerine
        // en yakın maç günü baz alınır.
        var selectedDate = matches
            .OrderBy(x => x.MatchDate)
            .Select(x => x.MatchDate.Date)
            .FirstOrDefault();

        var todayMatches = matches
            .Where(x => x.MatchDate.Date == selectedDate)
            .OrderBy(x => x.MatchTime)
            .ToList();

        var model = new DashboardViewModel
        {
            TotalMatches = matches.Count,
            LiveMatches = matches.Count(x => x.Status == 1),
            FinishedMatches = matches.Count(x => x.Status == 2),
            UpcomingMatches = matches.Count(x => x.Status == 0),

            TotalGoals = details.Count(x => x.ActionType.ToString() == "Goal"),
            TotalEvents = details.Count,

            Teams = teams.Take(8).ToList(),
            TodayMatches = todayMatches
        };

        return View(model);
    }
}
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;
using PrLeagueX.DtoLayer.MatchDetailDtos;
using PrLeagueX.DtoLayer.MatchDtos;
using PrLeagueX.Entity.Enums;
using System.Text;

namespace PrLeagueX.WebUI.Areas.Admin.Controllers;

[Area("Admin")]
public class MatchDetailController : Controller
{
    private readonly IHttpClientFactory _httpClientFactory;

    public MatchDetailController(IHttpClientFactory httpClientFactory)
    {
        _httpClientFactory = httpClientFactory;
    }

    private async Task LoadMatchTeams(int matchId)
    {
        var client = _httpClientFactory.CreateClient();

        var response = await client.GetAsync($"http://localhost:5164/api/Match/GetMatch?id={matchId}");

        if (response.IsSuccessStatusCode)
        {
            var json = await response.Content.ReadAsStringAsync();
            var match = JsonConvert.DeserializeObject<ResultMatchCardDto>(json);

            ViewBag.Teams = new SelectList(new[]
            {
                new
                {
                    TeamId = match.HomeTeamId,
                    TeamName = match.HomeTeamName
                },
                new
                {
                    TeamId = match.AwayTeamId,
                    TeamName = match.AwayTeamName
                }
            }, "TeamId", "TeamName");
        }

        ViewBag.MatchId = matchId;
    }

    [HttpGet]
    public async Task<IActionResult> CreateGoal(int id)
    {
        await LoadMatchTeams(id);

        return View(new CreateMatchDetailDto
        {
            MatchId = id,
            ActionType = MatchActionType.Goal
        });
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> CreateGoal(CreateMatchDetailDto dto)
    {
        dto.ActionType = MatchActionType.Goal;

        var client = _httpClientFactory.CreateClient();

        var json = JsonConvert.SerializeObject(dto);
        var content = new StringContent(json, Encoding.UTF8, "application/json");

        var response = await client.PostAsync("http://localhost:5164/api/MatchDetails", content);

        if (response.IsSuccessStatusCode)
        {
            return RedirectToAction("Manage", "MatchEvent", new { id = dto.MatchId });
        }

        await LoadMatchTeams(dto.MatchId);
        return View(dto);
    }

    [HttpGet]
    public async Task<IActionResult> CreateCard(int id)
    {
        await LoadMatchTeams(id);

        return View(new CreateMatchDetailDto
        {
            MatchId = id
        });
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> CreateCard(CreateMatchDetailDto dto, string cardType)
    {
        dto.ActionType = cardType == "red"
            ? MatchActionType.RedCard
            : MatchActionType.YellowCard;

        var client = _httpClientFactory.CreateClient();

        var json = JsonConvert.SerializeObject(dto);
        var content = new StringContent(json, Encoding.UTF8, "application/json");

        var response = await client.PostAsync("http://localhost:5164/api/MatchDetails", content);

        if (response.IsSuccessStatusCode)
        {
            return RedirectToAction("Manage", "MatchEvent", new { id = dto.MatchId });
        }

        await LoadMatchTeams(dto.MatchId);
        return View(dto);
    }

    [HttpGet]
    public async Task<IActionResult> CreateSubstitution(int id)
    {
        await LoadMatchTeams(id);

        return View(new CreateMatchDetailDto
        {
            MatchId = id,
            ActionType = MatchActionType.Substitution
        });
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> CreateSubstitution(CreateMatchDetailDto dto)
    {
        dto.ActionType = MatchActionType.Substitution;

        var client = _httpClientFactory.CreateClient();

        var json = JsonConvert.SerializeObject(dto);
        var content = new StringContent(json, Encoding.UTF8, "application/json");

        var response = await client.PostAsync("http://localhost:5164/api/MatchDetails", content);

        if (response.IsSuccessStatusCode)
        {
            return RedirectToAction("Manage", "MatchEvent", new { id = dto.MatchId });
        }

        await LoadMatchTeams(dto.MatchId);
        return View(dto);
    }
}
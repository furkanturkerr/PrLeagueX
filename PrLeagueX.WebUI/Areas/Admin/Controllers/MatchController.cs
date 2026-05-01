using System.Text;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;
using PrLeagueX.DtoLayer.MatchDtos;
using PrLeagueX.DtoLayer.SeasonDtos;
using PrLeagueX.DtoLayer.TeamDtos;
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

    public async Task<IActionResult> CreateMatch()
    {
        var client = _httpClientFactory.CreateClient();
        
        var teamresponse = await client.GetAsync("http://localhost:5164/api/Teams");
        if (teamresponse.IsSuccessStatusCode)
        {
            var teamjsonData = await teamresponse.Content.ReadAsStringAsync();
            var team = JsonConvert.DeserializeObject<List<ResultTeamDto>>(teamjsonData);
            ViewBag.Teams = new SelectList(team, "TeamId", "TeamName");
        }
        
        var seasonresponse = await client.GetAsync("http://localhost:5164/api/Season");
        if (seasonresponse.IsSuccessStatusCode)
        {
            var seasonjsonData = await seasonresponse.Content.ReadAsStringAsync();
            var season = JsonConvert.DeserializeObject<List<ResultSeasonDto>>(seasonjsonData);
            ViewBag.Seasons = new SelectList(season, "SeasonId", "SeasonName");
        }
        
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> CreateMatch(CreateMatchDto dto)
    {
        var client = _httpClientFactory.CreateClient();
        var jsonData = JsonConvert.SerializeObject(dto);
        StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
        var response = await client.PostAsync("http://localhost:5164/api/Match", stringContent);
        
        if (!response.IsSuccessStatusCode)
        {
            var teamresponse = await client.GetAsync("http://localhost:5164/api/Teams");
            if (teamresponse.IsSuccessStatusCode)
            {
                var teamjsonData = await teamresponse.Content.ReadAsStringAsync();
                var team = JsonConvert.DeserializeObject<List<ResultTeamDto>>(teamjsonData);
                ViewBag.Teams = new SelectList(team, "TeamId", "TeamName");
            }
        
            var seasonresponse = await client.GetAsync("http://localhost:5164/api/Season");
            if (seasonresponse.IsSuccessStatusCode)
            {
                var seasonjsonData = await seasonresponse.Content.ReadAsStringAsync();
                var season = JsonConvert.DeserializeObject<List<ResultSeasonDto>>(seasonjsonData);
                ViewBag.Seasons = new SelectList(season, "SeasonId", "SeasonName");
            }
            
            return View();
        }
        return RedirectToAction("Index");
    }

    public async Task<IActionResult> DeleteMatch(int id)
    {
        var client = _httpClientFactory.CreateClient();
        await client.DeleteAsync("http://localhost:5164/api/Match?id=" + id);
        return RedirectToAction("Index");
    }

    public async Task<IActionResult> UpdateMatch(int id)
    {
        var client = _httpClientFactory.CreateClient();
        var response = await client.GetAsync("http://localhost:5164/api/Match/GetMatch?id=" + id);
        if (response.IsSuccessStatusCode)
        {
            var jsonData = await response.Content.ReadAsStringAsync();
            var values = JsonConvert.DeserializeObject<UpdateMatchDto>(jsonData);
            
            var teamresponse = await client.GetAsync("http://localhost:5164/api/Teams");
            if (teamresponse.IsSuccessStatusCode)
            {
                var teamjsonData = await teamresponse.Content.ReadAsStringAsync();
                var team = JsonConvert.DeserializeObject<List<ResultTeamDto>>(teamjsonData);
                ViewBag.Teams = new SelectList(team, "TeamId", "TeamName");
            }
        
            var seasonresponse = await client.GetAsync("http://localhost:5164/api/Season");
            if (seasonresponse.IsSuccessStatusCode)
            {
                var seasonjsonData = await seasonresponse.Content.ReadAsStringAsync();
                var season = JsonConvert.DeserializeObject<List<ResultSeasonDto>>(seasonjsonData);
                ViewBag.Seasons = new SelectList(season, "SeasonId", "SeasonName");
            }
            
            return View(values);
        }
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> UpdateMatch(UpdateMatchDto dto)
    {
        var client = _httpClientFactory.CreateClient();
        var jsonData = JsonConvert.SerializeObject(dto);
        StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
        var response = await client.PutAsync("http://localhost:5164/api/Match", stringContent);

        if (!response.IsSuccessStatusCode)
        {
            var teamresponse = await client.GetAsync("http://localhost:5164/api/Teams");
            if (teamresponse.IsSuccessStatusCode)
            {
                var teamjsonData = await teamresponse.Content.ReadAsStringAsync();
                var team = JsonConvert.DeserializeObject<List<ResultTeamDto>>(teamjsonData);
                ViewBag.Teams = new SelectList(team, "TeamId", "TeamName");
            }
        
            var seasonresponse = await client.GetAsync("http://localhost:5164/api/Season");
            if (seasonresponse.IsSuccessStatusCode)
            {
                var seasonjsonData = await seasonresponse.Content.ReadAsStringAsync();
                var season = JsonConvert.DeserializeObject<List<ResultSeasonDto>>(seasonjsonData);
                ViewBag.Seasons = new SelectList(season, "SeasonId", "SeasonName");
            }
            
            return View();
        }
        return RedirectToAction("Index");
    }
}
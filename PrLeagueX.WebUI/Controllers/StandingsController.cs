using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using PrLeagueX.DtoLayer.SeasonDtos;
using PrLeagueX.DtoLayer.StandingDtos;

namespace PrLeagueX.WebUI.Controllers;

public class StandingsController : Controller
{
    private readonly IHttpClientFactory _httpClientFactory;

    public StandingsController(IHttpClientFactory httpClientFactory)
    {
        _httpClientFactory = httpClientFactory; 
    }

    public async Task<IActionResult> Index(int? seasonId)
    {
        var client = _httpClientFactory.CreateClient(); 

        var seasons = new List<ResultSeasonDto>();

        // 1. Sezonları çekiyoruz (dropdown için)
        var seasonResponse = await client.GetAsync("http://localhost:5164/api/Season");

        if (seasonResponse.IsSuccessStatusCode)
        {
            var seasonJson = await seasonResponse.Content.ReadAsStringAsync();
            
            seasons = JsonConvert.DeserializeObject<List<ResultSeasonDto>>(seasonJson) ?? new List<ResultSeasonDto>();
        }

        // 2. Seçili sezonu belirleme
        // öncelik: kullanıcı seçti → yoksa aktif sezon → yoksa default 2
        var selectedSeasonId = seasonId 
                               ?? seasons.FirstOrDefault(x => x.IsActive)?.SeasonId 
                               ?? 2;

        var standings = new List<ResultStandingDto>();

        // 3. Seçilen sezona göre puan durumunu çekiyoruz
        var standingResponse = await client.GetAsync(
            $"http://localhost:5164/api/Standings/season/{selectedSeasonId}");

        if (standingResponse.IsSuccessStatusCode)
        {
            var standingJson = await standingResponse.Content.ReadAsStringAsync();

            standings = JsonConvert.DeserializeObject<List<ResultStandingDto>>(standingJson) 
                        ?? new List<ResultStandingDto>();
        }
        
        ViewBag.Seasons = seasons;
        
        ViewBag.SelectedSeasonId = selectedSeasonId;
        
        return View(standings);
    }
}
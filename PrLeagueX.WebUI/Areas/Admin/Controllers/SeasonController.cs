using System.Text;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;
using PrLeagueX.DtoLayer.LeagueDtos;
using PrLeagueX.DtoLayer.SeasonDtos;

namespace PrLeagueX.WebUI.Areas.Admin.Controllers;
[Area("Admin")]
public class SeasonController : Controller
{
    private readonly IHttpClientFactory _httpClientFactory;

    public SeasonController(IHttpClientFactory httpClientFactory)
    {
        _httpClientFactory = httpClientFactory;
    }

    // GET
    public async Task<IActionResult> Index()
    {
        var client = _httpClientFactory.CreateClient();
        var response = await client.GetAsync("http://localhost:5164/api/Season");
        if (response.IsSuccessStatusCode)
        {
            var jsonData = await response.Content.ReadAsStringAsync();
            var values = JsonConvert.DeserializeObject<List<ResultSeasonDto>>(jsonData);
            return View(values);
        }
        return View();
    }

    [HttpGet]
    public async Task<IActionResult> CreateSeason()
    {
        var client = _httpClientFactory.CreateClient();
        var response = await client.GetAsync("http://localhost:5164/api/Leagues");
        if (response.IsSuccessStatusCode)
        {
            var jsonData = await response.Content.ReadAsStringAsync();
            var values = JsonConvert.DeserializeObject<List<ResultLeagueDto>>(jsonData);
            ViewBag.Leagues = new SelectList(values, "LeagueId", "LeagueName");
        }
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> CreateSeason(ResultSeasonDto dto)
    {
        var client = _httpClientFactory.CreateClient();
        var jsonData = JsonConvert.SerializeObject(dto);
        StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
        var response = await client.PostAsync("http://localhost:5164/api/Season", stringContent);
        if (response.IsSuccessStatusCode)
        {
            return RedirectToAction("Index");
        }
        return View(dto);
    }

    public async Task<IActionResult> UpdateSeason(int id)
    {
        var client = _httpClientFactory.CreateClient();
        var response = await client.GetAsync("http://localhost:5164/api/Season/GetSeason?id=" + id);
        if (response.IsSuccessStatusCode)
        {
            var jsonData = await response.Content.ReadAsStringAsync();
            var values = JsonConvert.DeserializeObject<UpdateSeasonDto>(jsonData);
            
            var leagueResponse = await client.GetAsync("http://localhost:5164/api/Leagues");

            if (leagueResponse.IsSuccessStatusCode)
            {
                var leaguejsonData = await leagueResponse.Content.ReadAsStringAsync();
                var leaguevalues = JsonConvert.DeserializeObject<List<ResultLeagueDto>>(leaguejsonData);
                ViewBag.Leagues = new SelectList(leaguevalues, "LeagueId", "LeagueName");
            }
            
            return View(values);
        }
        return View();  
    }

    [HttpPost]
    public async Task<IActionResult> UpdateSeason(UpdateSeasonDto dto)
    {
        var client = _httpClientFactory.CreateClient();
        var jsonData = JsonConvert.SerializeObject(dto);
        StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
        var response = await client.PutAsync("http://localhost:5164/api/Season", stringContent);
        if (response.IsSuccessStatusCode)
        {
            return RedirectToAction("Index");
        }
        return View(dto); 
    }

    public async Task<IActionResult> DeleteSeason(int id)
    {
        var client = _httpClientFactory.CreateClient();
        await client.DeleteAsync("http://localhost:5164/api/Season?id=" + id);
        return RedirectToAction("Index");   
    }
}
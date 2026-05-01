using System.Text;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;
using PrLeagueX.DtoLayer.StadiumDtos;
using PrLeagueX.DtoLayer.TeamDtos;

namespace PrLeagueX.WebUI.Areas.Admin.Controllers;
[Area("Admin")]
public class TeamController : Controller
{
    private readonly IHttpClientFactory _httpClientFactory;

    public TeamController(IHttpClientFactory httpClientFactory)
    {
        _httpClientFactory = httpClientFactory;
    }

    // GET
    public async Task<IActionResult> Index()
    {
        var client = _httpClientFactory.CreateClient();
        var response = await client.GetAsync("http://localhost:5164/api/Teams/TeamListWithStadiums");
        if (response.IsSuccessStatusCode)
        {
            var jsonData = await response.Content.ReadAsStringAsync();
            var values = JsonConvert.DeserializeObject<List<ResultTeamDto>>(jsonData);
            return View(values);
        }
        return View();
    }

    public async Task<IActionResult> CreateTeam()
    {
        var client = _httpClientFactory.CreateClient();
        var response = await client.GetAsync("http://localhost:5164/api/Stadiums");
        if (response.IsSuccessStatusCode)
        {
            var jsonData = await response.Content.ReadAsStringAsync();
            var stadiums = JsonConvert.DeserializeObject<List<ResultStadiumDto>>(jsonData);
            ViewBag.Stadiums = new SelectList(stadiums, "StadiumId", "StadiumName");
        }
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> CreateTeam(CreateTeamDto dto)
    {
        var client = _httpClientFactory.CreateClient();
        var jsonData = JsonConvert.SerializeObject(dto);
        StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
        var response = await client.PostAsync("http://localhost:5164/api/Teams", stringContent);
        if (response.IsSuccessStatusCode)
        {
            return RedirectToAction("Index");
        }
        return View(dto);
    }

    [HttpGet]
    public async Task<IActionResult> UpdateTeam(int id)
    {
        var client = _httpClientFactory.CreateClient();
        var response = await client.GetAsync("http://localhost:5164/api/Teams/GetTeam?id=" + id);
        if (response.IsSuccessStatusCode)
        {
            var jsonData = await response.Content.ReadAsStringAsync();
            var values = JsonConvert.DeserializeObject<UpdateTeamDto>(jsonData);
            
            var stadiumResponse = await client.GetAsync("http://localhost:5164/api/Stadiums");

            if (stadiumResponse.IsSuccessStatusCode)
            {
                var stadiumJson = await stadiumResponse.Content.ReadAsStringAsync();
                var stadiums = JsonConvert.DeserializeObject<List<ResultStadiumDto>>(stadiumJson);

                ViewBag.Stadiums = new SelectList(
                    stadiums,
                    "StadiumId",
                    "StadiumName"
                );
            }
            
            return View(values);
        }
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> UpdateTeam(UpdateTeamDto dto)
    {
        var client = _httpClientFactory.CreateClient();
        var jsonData = JsonConvert.SerializeObject(dto);
        StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
        var response = await client.PutAsync("http://localhost:5164/api/Teams", stringContent);
        if (response.IsSuccessStatusCode)
        {
            return RedirectToAction("Index");
        }
        return View(dto);   
    }
    
    public async Task<IActionResult> DeleteTeam(int id)
    {
        var client = _httpClientFactory.CreateClient();
        await client.DeleteAsync("http://localhost:5164/api/Teams?id="+ id);
        return RedirectToAction("Index");
    }
}
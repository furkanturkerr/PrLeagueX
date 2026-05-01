using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;
using PrLeagueX.DtoLayer.MatchStatisticDtos;

namespace PrLeagueX.WebUI.Areas.Admin.Controllers;

[Area("Admin")]
public class MatchStatisticController : Controller
{
    private readonly IHttpClientFactory _httpClientFactory;

    public MatchStatisticController(IHttpClientFactory httpClientFactory)
    {
        _httpClientFactory = httpClientFactory;
    }

    [HttpGet]
    public async Task<IActionResult> CreateOrUpdate(int id)
    {
        ViewBag.MatchId = id;

        var client = _httpClientFactory.CreateClient();
        var response = await client.GetAsync($"http://localhost:5164/api/MatchStatistics/match/{id}");

        if (response.IsSuccessStatusCode)
        {
            var json = await response.Content.ReadAsStringAsync();

            var value = JsonConvert.DeserializeObject<ResultMatchStatisticDto>(json);

            if (value != null)
                return View(value);
        }

        return View(new CreateMatchStatisticDto { MatchId = id });
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> CreateOrUpdate(CreateMatchStatisticDto dto)
    {
        var client = _httpClientFactory.CreateClient();

        var json = JsonConvert.SerializeObject(dto);
        var content = new StringContent(json, Encoding.UTF8, "application/json");

        await client.PostAsync("http://localhost:5164/api/MatchStatistics", content);

        return RedirectToAction("Manage", "MatchEvent", new { id = dto.MatchId });
    }
}
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using PrLeagueX.DtoLayer.MatchDetailDtos;
using PrLeagueX.DtoLayer.MatchDtos;
using PrLeagueX.DtoLayer.MatchStatisticDtos;
using PrLeagueX.WebUI.Models;

namespace PrLeagueX.WebUI.Controllers;

public class MatchController : Controller
{
    private readonly IHttpClientFactory _httpClientFactory;

    public MatchController(IHttpClientFactory httpClientFactory)
    {
        _httpClientFactory = httpClientFactory;
    }

    [HttpGet("/Match/Detail/{id:int}")]
    public async Task<IActionResult> Detail(int id)
    {
        var client = _httpClientFactory.CreateClient();

        var matchJson = await client
            .GetStringAsync($"http://localhost:5164/api/Match/GetMatch?id={id}");

        var match = JsonConvert.DeserializeObject<ResultMatchCardDto>(matchJson);

        var detailsJson = await client
            .GetStringAsync($"http://localhost:5164/api/MatchDetails/match/{id}");

        var details = JsonConvert.DeserializeObject<List<ResultMatchDetailDto>>(detailsJson)
                      ?? new List<ResultMatchDetailDto>();

        ResultMatchStatisticDto? statistic = null;

        var statisticResponse = await client.GetAsync($"http://localhost:5164/api/MatchStatistics/{id}");

        if (statisticResponse.IsSuccessStatusCode)
        {
            var statisticJson = await statisticResponse.Content.ReadAsStringAsync();
            statistic = JsonConvert.DeserializeObject<ResultMatchStatisticDto>(statisticJson);
        }

        var orderedDetails = details.OrderBy(x => x.Minute).ToList();

        var model = new MatchDetailPageViewModel
        {
            Match = match!,
            Details = orderedDetails,
            Statistic = statistic,

            Goals = orderedDetails
                .Where(x => x.ActionType.ToString() == "Goal")
                .ToList(),

            Cards = orderedDetails
                .Where(x =>
                    x.ActionType.ToString() == "YellowCard" ||
                    x.ActionType.ToString() == "RedCard")
                .ToList(),

            Substitutions = orderedDetails
                .Where(x => x.ActionType.ToString() == "Substitution")
                .ToList()
        };

        return View(model);
    }
}
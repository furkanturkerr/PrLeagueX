using Microsoft.AspNetCore.Mvc;
using PrLeagueX.BusinessLayer.Abstract;

namespace PrLeagueX.WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class DefaultMatchesController : ControllerBase
{
    private readonly IDefaultMatchService _defaultMatchService;

    public DefaultMatchesController(IDefaultMatchService defaultMatchService)
    {
        _defaultMatchService = defaultMatchService;
    }

    [HttpGet("season/{seasonId:int}/week/{week:int}")]
    public async Task<IActionResult> GetMatchesBySeasonAndWeek(int seasonId, int week)
    {
        var values = await _defaultMatchService.TGetMatchesBySeasonAndWeekAsync(seasonId, week);
        return Ok(values);
    }
}
using Microsoft.AspNetCore.Mvc;
using PrLeagueX.BusinessLayer.Abstract;

namespace PrLeagueX.WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class FixtureController : ControllerBase
{
    private readonly IFixtureService _fixtureService;

    public FixtureController(IFixtureService fixtureService)
    {
        _fixtureService = fixtureService;
    }

    [HttpGet("season/{seasonId:int}/week/{week:int}")]
    public async Task<IActionResult> GetFixturesBySeasonAndWeek(int seasonId, int week)
    {
        var values = await _fixtureService.TGetMatchesBySeasonAndWeekAsync(seasonId, week);
        return Ok(values);
    }
}
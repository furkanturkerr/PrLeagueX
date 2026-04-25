using Microsoft.AspNetCore.Mvc;
using PrLeagueX.BusinessLayer.Abstract;

namespace PrLeagueX.WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class StandingsController : ControllerBase
{
    private readonly IStandingService _standingService;

    public StandingsController(IStandingService standingService)
    {
        _standingService = standingService;
    }

    [HttpGet("season/{seasonId:int}")]
    public async Task<IActionResult> GetStandingsBySeason(int seasonId)
    {
        var values = await _standingService.TGetStandingsAsync(seasonId);
        return Ok(values);
    }
}
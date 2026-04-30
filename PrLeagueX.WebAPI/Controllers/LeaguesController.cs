using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PrLeagueX.BusinessLayer.Abstract;

namespace PrLeagueX.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LeaguesController : ControllerBase
    {
        private readonly ILeagueService _leagueService;

        public LeaguesController(ILeagueService leagueService)
        {
            _leagueService = leagueService;
        }

        [HttpGet]
        public async Task<IActionResult> LeagueList()
        {
            var values = await _leagueService.TGetListAsync();
            return Ok(values);
        }
    }
}

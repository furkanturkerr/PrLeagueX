using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PrLeagueX.BusinessLayer.Abstract;

namespace PrLeagueX.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MatchController : ControllerBase
    {
        private readonly IMatchService _matchService;

        public MatchController(IMatchService matchService)
        {
            _matchService = matchService;
        }
        
        [HttpGet]
        public async Task<IActionResult> GetMatches()
        {
            var values = await _matchService.TGetListAsync();
            return Ok(values);
        }
    }
}

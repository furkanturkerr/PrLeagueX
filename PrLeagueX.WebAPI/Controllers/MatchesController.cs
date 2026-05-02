using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using PrLeagueX.BusinessLayer.Abstract;
using PrLeagueX.DtoLayer.MatchDtos;

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

        [HttpGet("season/{seasonId:int}/week/{week:int}")]
        public async Task<IActionResult> GetMatchesBySeasonAndWeekAsync(int seasonId, int week)
        {
            var values = await _matchService.TGetMatchesBySeasonAndWeekAsync(seasonId, week);
            return Ok(values);
        }

        [HttpPost]
        public async Task<IActionResult> CreateMatch(CreateMatchDto dto)
        {
            await _matchService.TInsertAsync(dto);
            return Ok("Ekleme işlemi başarılı");
        }

        [HttpPut]
        public async Task<IActionResult> UpdateMatch(UpdateMatchDto dto)
        {
            await _matchService.TUpdateAsync(dto);
            return Ok("Güncelleme Başarılı");
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteMatch(int id)
        {
            await _matchService.TDeleteAsync(id);
            return Ok("Silme Başaarılı");
        }

        [HttpGet("GetMatch")]
        public async Task<IActionResult> GetMatch(int id)
        {
            var values = await _matchService.TGetByIdAsync(id);
            return Ok(values);
        }

        [HttpGet("GetMatchWithDetails")]
        public async Task<IActionResult> GetMatchWithDetails(int id)
        {
            var values = await _matchService.GetMatchWithDetailsByIdAsync(id);
            return Ok(values);
        }
    }
}

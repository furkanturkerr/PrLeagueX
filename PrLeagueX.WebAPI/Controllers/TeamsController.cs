using Microsoft.AspNetCore.Mvc;
using PrLeagueX.BusinessLayer.Abstract;
using PrLeagueX.DtoLayer.TeamDtos;

namespace PrLeagueX.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TeamsController : ControllerBase
    {
        private readonly ITeamService _teamService;

        public TeamsController(ITeamService teamService)
        {
            _teamService = teamService;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var values = await _teamService.TGetListAsync();
            return Ok(values);
        }
        
        [HttpPost]
        public async Task<IActionResult> CreateTeam(CreateTeamDto dto)
        {
            await _teamService.TInsertAsync(dto);
            return Ok("Ekleme Başarılı");
        }

        [HttpPut]
        public async Task<IActionResult> UpdateTeam(UpdateTeamDto dto)
        {
            await _teamService.TUpdateAsync(dto);
            return Ok("Güncelleme Başarılı");
        }
        
        [HttpDelete]
        public async Task<IActionResult> DeleteTeam(int id)
        {
            await _teamService.TDeleteAsync(id);
            return Ok("Silme Başarılı");
        }
        
        [HttpGet("GetTeam")]
        public async Task<IActionResult> GetTeamById(int id)
        {
            var values = await _teamService.TGetByIdAsync(id);
            return Ok(values);
        }
    }
}

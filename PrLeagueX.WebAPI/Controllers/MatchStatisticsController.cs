using Microsoft.AspNetCore.Mvc;
using PrLeagueX.BusinessLayer.Abstract;
using PrLeagueX.DtoLayer.MatchStatisticDtos;

namespace PrLeagueX.WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class MatchStatisticsController : ControllerBase
{
    private readonly IMatchStatisticService _matchStatisticService;

    public MatchStatisticsController(IMatchStatisticService matchStatisticService)
    {
        _matchStatisticService = matchStatisticService;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var values = await _matchStatisticService.TGetListAsync();
        return Ok(values);
    }

    [HttpGet("{id:int}")]
    public async Task<IActionResult> GetById(int id)
    {
        var value = await _matchStatisticService.TGetByIdAsync(id);

        if (value == null)
            return NotFound();

        return Ok(value);
    }

    [HttpGet("match/{matchId:int}")]
    public async Task<IActionResult> GetByMatchId(int matchId)
    {
        var value = await _matchStatisticService.TGetByMatchIdAsync(matchId);

        if (value == null)
            return NotFound();

        return Ok(value);
    }

    [HttpPost]
    public async Task<IActionResult> Create(CreateMatchStatisticDto dto)
    {
        await _matchStatisticService.TInsertAsync(dto);
        return Ok("Maç istatistiği eklendi.");
    }

    [HttpPut]
    public async Task<IActionResult> Update(UpdateMatchStatisticDto dto)
    {
        await _matchStatisticService.TUpdateAsync(dto);
        return Ok("Maç istatistiği güncellendi.");
    }

    [HttpDelete("{id:int}")]
    public async Task<IActionResult> Delete(int id)
    {
        await _matchStatisticService.TDeleteAsync(id);
        return Ok("Maç istatistiği silindi.");
    }
}
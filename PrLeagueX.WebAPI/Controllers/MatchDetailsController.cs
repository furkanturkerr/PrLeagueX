using Microsoft.AspNetCore.Mvc;
using PrLeagueX.BusinessLayer.Abstract;
using PrLeagueX.DtoLayer.MatchDetailDtos;

namespace PrLeagueX.WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class MatchDetailsController : ControllerBase
{
    private readonly IMatchDetailService _matchDetailService;

    public MatchDetailsController(IMatchDetailService matchDetailService)
    {
        _matchDetailService = matchDetailService;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var values = await _matchDetailService.TGetListAsync();
        return Ok(values);
    }

    [HttpGet("{id:int}")]
    public async Task<IActionResult> GetById(int id)
    {
        var value = await _matchDetailService.TGetByIdAsync(id);
        return Ok(value);
    }

    [HttpGet("match/{matchId:int}")]
    public async Task<IActionResult> GetByMatchId(int matchId)
    {
        var values = await _matchDetailService.TGetByMatchIdAsync(matchId);
        return Ok(values);
    }

    [HttpPost]
    public async Task<IActionResult> Create(CreateMatchDetailDto dto)
    {
        await _matchDetailService.TInsertAsync(dto);
        return Ok("Maç olayı eklendi.");
    }

    [HttpPut]
    public async Task<IActionResult> Update(UpdateMatchDetailDto dto)
    {
        await _matchDetailService.TUpdateAsync(dto);
        return Ok("Maç olayı güncellendi.");
    }

    [HttpDelete("{id:int}")]
    public async Task<IActionResult> Delete(int id)
    {
        await _matchDetailService.TDeleteAsync(id);
        return Ok("Maç olayı silindi.");
    }
}
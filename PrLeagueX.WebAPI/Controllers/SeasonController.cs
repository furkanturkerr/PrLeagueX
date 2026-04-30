using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PrLeagueX.BusinessLayer.Abstract;
using PrLeagueX.DtoLayer.SeasonDtos;

namespace PrLeagueX.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SeasonController : ControllerBase
    {
        private readonly ISeasonService _seasonService;

        public SeasonController(ISeasonService seasonService)
        {
            _seasonService = seasonService;
        }
        
        [HttpGet]
        public async Task<IActionResult> GetList()
        {
            var result = await _seasonService.TGetListAsync();
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> CreateSeason(CreateSeasonDto dto)
        {
            await _seasonService.TInsertAsync(dto);
            return Ok("Ekleme işlemi başarılı");
        }
        
        [HttpPut]
        public async Task<IActionResult> UpdateSeason(UpdateSeasonDto dto)
        {
            await _seasonService.TUpdateAsync(dto);
            return Ok("Güncelleme işlemi başarılı");
        }
        
        [HttpDelete]
        public async Task<IActionResult> DeleteSeason(int id)
        {
            await _seasonService.TDeleteAsync(id);
            return Ok("Silme işlemi başarılı");
        }
        
        [HttpGet("GetSeason")]
        public async Task<IActionResult> GetSeasonById(int id)
        {
            var values = await _seasonService.TGetByIdAsync(id);
            return Ok(values);
        }
    }
}

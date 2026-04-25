using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PrLeagueX.BusinessLayer.Abstract;

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
    }
}

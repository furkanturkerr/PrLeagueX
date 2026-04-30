using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PrLeagueX.BusinessLayer.Abstract;

namespace PrLeagueX.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StadiumsController : ControllerBase
    {
        private readonly IStadiumService _stadiumService;

        public StadiumsController(IStadiumService stadiumService)
        {
            _stadiumService = stadiumService;
        }

        [HttpGet]
        public async Task<IActionResult> StadiumList()
        {
            var values = await _stadiumService.TGetListAsync();
            return Ok(values);
        }
    }
}

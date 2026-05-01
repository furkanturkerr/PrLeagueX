using PrLeagueX.DtoLayer.MatchDtos;
using PrLeagueX.DtoLayer.SeasonDtos;

namespace PrLeagueX.WebUI.Areas.Admin.Models;

public class MatchListViewModel
{
    public List<ResultMatchDto> Matches { get; set; } = new();

    public List<ResultSeasonDto> Seasons { get; set; } = new();

    public int SelectedSeasonId { get; set; }

    public int SelectedWeek { get; set; }
}
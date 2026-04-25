using PrLeagueX.DtoLayer.MatchDtos;
using PrLeagueX.DtoLayer.SeasonDtos;

namespace PrLeagueX.WebUI.Models;

public class FixturePageViewModel
{
    public List<ResultFixtureDto> Fixtures { get; set; } = new();

    public List<ResultSeasonDto> Seasons { get; set; } = new();

    public int SelectedSeasonId { get; set; }

    public int SelectedWeek { get; set; }

    public int TotalWeeks { get; set; } = 38;
}
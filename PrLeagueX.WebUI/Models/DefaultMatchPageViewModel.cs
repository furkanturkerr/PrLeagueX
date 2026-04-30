using PrLeagueX.DtoLayer.MatchDtos;
using PrLeagueX.DtoLayer.SeasonDtos;

namespace PrLeagueX.WebUI.Models;

public class DefaultMatchPageViewModel
{
    public List<ResultMatchCardDto> Matches { get; set; } = new();
    public List<ResultSeasonDto> Seasons { get; set; } = new();

    public int SelectedSeasonId { get; set; }
    public int SelectedWeek { get; set; }

    public int LiveCount { get; set; }
    public int FinishedCount { get; set; }
    public int UpcomingCount { get; set; }

    public ResultMatchCardDto? FeaturedMatch { get; set; }
}
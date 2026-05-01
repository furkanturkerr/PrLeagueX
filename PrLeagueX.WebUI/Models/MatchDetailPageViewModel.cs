using PrLeagueX.DtoLayer.MatchDetailDtos;
using PrLeagueX.DtoLayer.MatchDtos;
using PrLeagueX.DtoLayer.MatchStatisticDtos;

namespace PrLeagueX.WebUI.Models;

public class MatchDetailPageViewModel
{
    public ResultMatchCardDto Match { get; set; }

    public List<ResultMatchDetailDto> Details { get; set; } = new();

    public ResultMatchStatisticDto? Statistic { get; set; }

    public List<ResultMatchDetailDto> Goals { get; set; } = new();
    public List<ResultMatchDetailDto> Cards { get; set; } = new();
    public List<ResultMatchDetailDto> Substitutions { get; set; } = new();
}
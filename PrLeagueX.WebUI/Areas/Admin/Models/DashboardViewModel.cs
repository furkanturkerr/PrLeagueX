using PrLeagueX.DtoLayer.MatchDtos;
using PrLeagueX.DtoLayer.TeamDtos;

namespace PrLeagueX.WebUI.Areas.Admin.Models;

public class DashboardViewModel
{
    public int TotalMatches { get; set; }
    public int LiveMatches { get; set; }
    public int FinishedMatches { get; set; }
    public int UpcomingMatches { get; set; }

    public int TotalGoals { get; set; }
    public int TotalEvents { get; set; }

    public List<ResultTeamDto> Teams { get; set; } = new();
    public List<ResultMatchDto> TodayMatches { get; set; } = new();
}
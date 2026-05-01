using PrLeagueX.Entity.Enums;

namespace PrLeagueX.Entity.Entities;

public class MatchDetail
{
    public int MatchDetailId { get; set; }

    public int MatchId { get; set; }
    public Match Match { get; set; }

    public MatchActionType ActionType { get; set; }

    public string Description { get; set; }
    
    public int? TeamId { get; set; }
    public Team Team { get; set; }

    public int Minute { get; set; }
}
namespace PrLeagueX.Entity.Entities;

public class Season
{
    public int SeasonId { get; set; }

    public string SeasonName { get; set; } // 2025/2026

    public int LeagueId { get; set; }
    public League League { get; set; }

    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }

    public bool IsActive { get; set; }

    public List<Match> Matches { get; set; }
}
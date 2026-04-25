namespace PrLeagueX.Entity.Entities;

public class League
{
    public int LeagueId { get; set; }

    public string LeagueName { get; set; }
    public string Country { get; set; }
    public string LogoUrl { get; set; }

    public List<Season> Seasons { get; set; }
}
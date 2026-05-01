namespace PrLeagueX.Entity.Entities;

public class Team
{
    public int TeamId { get; set; }

    public string TeamName { get; set; }
    public string ShortName { get; set; }
    public string LogoUrl { get; set; }
    public string City { get; set; }
    public int FoundedYear { get; set; }

    public bool IsActive { get; set; } = true;
    
    public int StadiumId { get; set; }
    public Stadium Stadium { get; set; }

    public List<Match> HomeMatches { get; set; }
    public List<Match> AwayMatches { get; set; }
    public List<MatchDetail> MatchDetails { get; set; }
}
namespace PrLeagueX.DtoLayer.MatchDtos;

public class ResultMatchDto
{
    public int MatchId { get; set; }

    public int HomeTeamId { get; set; }

    public int AwayTeamId { get; set; }

    public DateTime MatchDate { get; set; }
    public string MatchTime { get; set; }

    public string StadiumName { get; set; }

    public int Week { get; set; }

    public int? HomeScore { get; set; }
    public int? AwayScore { get; set; }

    public int Status { get; set; }
    
    public int SeasonId { get; set; }
}
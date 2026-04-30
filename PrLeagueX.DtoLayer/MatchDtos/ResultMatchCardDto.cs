namespace PrLeagueX.DtoLayer.MatchDtos;

public class ResultMatchCardDto
{
    public int MatchId { get; set; }

    public int Week { get; set; }
    public DateTime MatchDate { get; set; }
    public string MatchTime { get; set; }
    public string StadiumName { get; set; }

    // 0: Oynanmadı, 1: Devam ediyor, 2: Bitti
    public int Status { get; set; }

    public int? HomeScore { get; set; }
    public int? AwayScore { get; set; }

    public int HomeTeamId { get; set; }
    public string HomeTeamName { get; set; }
    public string HomeTeamShortName { get; set; }
    public string HomeTeamLogoUrl { get; set; }

    public int AwayTeamId { get; set; }
    public string AwayTeamName { get; set; }
    public string AwayTeamShortName { get; set; }
    public string AwayTeamLogoUrl { get; set; }
}
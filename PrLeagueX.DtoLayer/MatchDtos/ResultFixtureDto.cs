namespace PrLeagueX.DtoLayer.MatchDtos;

public class ResultFixtureDto
{
    // Matches tablosu
    public int MatchId { get; set; }

    // Matches tablosu
    public int Week { get; set; }

    // Matches tablosu
    public DateTime MatchDate { get; set; }

    // Matches tablosu
    public string MatchTime { get; set; }

    // Matches tablosu
    public string StadiumName { get; set; }

    // Matches tablosu
    public int Status { get; set; }

    // Matches tablosu
    public int? HomeScore { get; set; }

    // Matches tablosu
    public int? AwayScore { get; set; }

    // HomeTeam bilgileri - Teams tablosu
    public int HomeTeamId { get; set; }
    public string HomeTeamName { get; set; }
    public string HomeTeamShortName { get; set; }
    public string HomeTeamLogoUrl { get; set; }

    // AwayTeam bilgileri - Teams tablosu
    public int AwayTeamId { get; set; }
    public string AwayTeamName { get; set; }
    public string AwayTeamShortName { get; set; }
    public string AwayTeamLogoUrl { get; set; }
}
namespace PrLeagueX.DtoLayer.TeamDtos;

public class ResultTeamDto
{
    public int TeamId { get; set; }

    public string TeamName { get; set; }
    public string ShortName { get; set; }
    public string LogoUrl { get; set; }
    public string City { get; set; }
    public string StadiumName { get; set; }
    public int FoundedYear { get; set; }

    public bool IsActive { get; set; } = true;
    
    public int? StadiumId { get; set; }
}
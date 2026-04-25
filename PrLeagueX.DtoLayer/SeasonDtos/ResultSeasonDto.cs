namespace PrLeagueX.DtoLayer.SeasonDtos;

public class ResultSeasonDto
{
    public int SeasonId { get; set; }

    public string SeasonName { get; set; } 

    public int LeagueId { get; set; }

    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }

    public bool IsActive { get; set; }
}
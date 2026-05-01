using PrLeagueX.Entity.Enums;

namespace PrLeagueX.DtoLayer.MatchDetailDtos;

public class CreateMatchDetailDto
{
    public int MatchId { get; set; }

    public int TeamId { get; set; }

    public MatchActionType ActionType { get; set; }

    public string Description { get; set; }

    public int Minute { get; set; }
}
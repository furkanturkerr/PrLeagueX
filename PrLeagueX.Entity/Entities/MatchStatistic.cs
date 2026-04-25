namespace PrLeagueX.Entity.Entities;

public class MatchStatistic
{
    public int MatchStatisticId { get; set; }

    public int MatchId { get; set; }
    public Match Match { get; set; }

    public int HomeFirstHalfGoals { get; set; }
    public int AwayFirstHalfGoals { get; set; }

    public int HomeSecondHalfGoals { get; set; }
    public int AwaySecondHalfGoals { get; set; }

    public int HomeBallPossession { get; set; }
    public int AwayBallPossession { get; set; }

    public int HomeShots { get; set; }
    public int AwayShots { get; set; }

    public int HomeShotsOnTarget { get; set; }
    public int AwayShotsOnTarget { get; set; }

    public int HomeCorners { get; set; }
    public int AwayCorners { get; set; }

    public int HomeFouls { get; set; }
    public int AwayFouls { get; set; }

    public int HomeYellowCards { get; set; }
    public int AwayYellowCards { get; set; }

    public int HomeRedCards { get; set; }
    public int AwayRedCards { get; set; }
}
using PrLeagueX.Entity.Entities;

namespace PrLeagueX.DataAccessLayer.Abstract;

public interface IMatchStatisticDal : IGenericDal<MatchStatistic>
{
    Task<MatchStatistic?> GetStatisticByMatchIdAsync(int matchId);
}
using PrLeagueX.Entity.Entities;

namespace PrLeagueX.DataAccessLayer.Abstract;

public interface IMatchDal : IGenericDal<Match>
{
    Task<List<Match>> GetFinishedMatchesBySeasonAsync(int seasonId);
    Task<List<Match>> GetFixturesBySeasonAndWeekAsync(int seasonId, int week);
}
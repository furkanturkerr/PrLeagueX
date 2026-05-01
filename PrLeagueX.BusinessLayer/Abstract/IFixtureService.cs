using PrLeagueX.DtoLayer.MatchDtos;

namespace PrLeagueX.BusinessLayer.Abstract;

public interface IFixtureService
{
    Task<List<ResultFixtureDto>> TGetMatchesBySeasonAndWeekAsync(int seasonId, int week);
}
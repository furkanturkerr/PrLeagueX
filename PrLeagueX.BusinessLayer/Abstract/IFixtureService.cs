using PrLeagueX.DtoLayer.MatchDtos;

namespace PrLeagueX.BusinessLayer.Abstract;

public interface IFixtureService
{
    Task<List<ResultFixtureDto>> TGetFixturesBySeasonAndWeekAsync(int seasonId, int week);
}
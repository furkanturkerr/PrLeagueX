using PrLeagueX.DtoLayer.MatchDtos;

namespace PrLeagueX.BusinessLayer.Abstract;

public interface IDefaultMatchService
{
    Task<List<ResultMatchCardDto>> TGetMatchesBySeasonAndWeekAsync(int seasonId, int week);
}
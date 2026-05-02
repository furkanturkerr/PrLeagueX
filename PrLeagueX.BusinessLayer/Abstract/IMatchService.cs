using PrLeagueX.DtoLayer.MatchDtos;

namespace PrLeagueX.BusinessLayer.Abstract;

public interface IMatchService : IGenericService<ResultMatchDto, CreateMatchDto, UpdateMatchDto>
{
    Task<List<ResultMatchDto>> TGetMatchesBySeasonAndWeekAsync(int seasonId, int week);
    Task<ResultMatchCardDto> GetMatchWithDetailsByIdAsync(int id);

}
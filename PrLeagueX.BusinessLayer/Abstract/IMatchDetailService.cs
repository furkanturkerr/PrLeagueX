using PrLeagueX.DtoLayer.MatchDetailDtos;

namespace PrLeagueX.BusinessLayer.Abstract;

public interface IMatchDetailService 
    : IGenericService<ResultMatchDetailDto, CreateMatchDetailDto, UpdateMatchDetailDto>
{
    Task<List<ResultMatchDetailDto>> TGetByMatchIdAsync(int matchId);
}
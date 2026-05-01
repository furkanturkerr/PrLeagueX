using PrLeagueX.DtoLayer.MatchStatisticDtos;

namespace PrLeagueX.BusinessLayer.Abstract;

public interface IMatchStatisticService 
    : IGenericService<ResultMatchStatisticDto, CreateMatchStatisticDto, UpdateMatchStatisticDto>
{
    Task<ResultMatchStatisticDto?> TGetByMatchIdAsync(int matchId);
}
using PrLeagueX.DtoLayer.StandingDtos;

namespace PrLeagueX.BusinessLayer.Abstract;

public interface IStandingService
{
    Task<List<ResultStandingDto>> TGetStandingsAsync(int seasonId);
    
}
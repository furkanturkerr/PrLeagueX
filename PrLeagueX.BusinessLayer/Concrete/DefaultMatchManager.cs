using AutoMapper;
using PrLeagueX.BusinessLayer.Abstract;
using PrLeagueX.DataAccessLayer.Abstract;
using PrLeagueX.DtoLayer.MatchDtos;

namespace PrLeagueX.BusinessLayer.Concrete;

public class DefaultMatchManager : IDefaultMatchService
{
    private readonly IMatchDal _matchDal;
    private readonly IMapper _mapper;

    public DefaultMatchManager(IMatchDal matchDal, IMapper mapper)
    {
        _matchDal = matchDal;
        _mapper = mapper;
    }

    public async Task<List<ResultMatchCardDto>> TGetMatchesBySeasonAndWeekAsync(int seasonId, int week)
    {
        var matches = await _matchDal.GetMatchesBySeasonAndWeekAsync(seasonId, week);
        return _mapper.Map<List<ResultMatchCardDto>>(matches);
    }
}
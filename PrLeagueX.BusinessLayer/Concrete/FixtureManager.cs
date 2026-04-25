using AutoMapper;
using PrLeagueX.BusinessLayer.Abstract;
using PrLeagueX.DataAccessLayer.Abstract;
using PrLeagueX.DtoLayer.MatchDtos;

namespace PrLeagueX.BusinessLayer.Concrete;

public class FixtureManager : IFixtureService
{
    private readonly IMatchDal _matchDal;
    private readonly IMapper _mapper;

    public FixtureManager(IMatchDal matchDal, IMapper mapper)
    {
        _matchDal = matchDal;
        _mapper = mapper;
    }

    public async Task<List<ResultFixtureDto>> TGetFixturesBySeasonAndWeekAsync(int seasonId, int week)
    {
        var matches = await _matchDal.GetFixturesBySeasonAndWeekAsync(seasonId, week);
        return _mapper.Map<List<ResultFixtureDto>>(matches);
    }
}
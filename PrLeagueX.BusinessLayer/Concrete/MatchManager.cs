using AutoMapper;
using PrLeagueX.BusinessLayer.Abstract;
using PrLeagueX.DataAccessLayer.Abstract;
using PrLeagueX.DtoLayer.MatchDtos;
using PrLeagueX.Entity.Entities;

namespace PrLeagueX.BusinessLayer.Concrete;

public class MatchManager : IMatchService
{
    private readonly IMatchDal _matchDal;
    private readonly IMapper _mapper;

    public MatchManager(IMatchDal matchDal, IMapper mapper)
    {
        _matchDal = matchDal;
        _mapper = mapper;
    }

    public async Task<List<ResultMatchDto>> TGetListAsync()
    {
        var values = _matchDal.GetListAsync();
        return _mapper.Map<List<ResultMatchDto>>(await values);
    }

    public async Task<UpdateMatchDto> TGetByIdAsync(int id)
    {
        var values = await _matchDal.GetByIdAsync(id);
        return _mapper.Map<UpdateMatchDto>(values);
    }

    public async Task TInsertAsync(CreateMatchDto dto)
    {
        var values = _mapper.Map<Match>(dto);
        await _matchDal.InsertAsync(values);
    }

    public async Task TUpdateAsync(UpdateMatchDto dto)
    {
        var values = _mapper.Map<Match>(dto);
        await _matchDal.UpdateAsync(values);
    }

    public async Task TDeleteAsync(int id)
    {
        await _matchDal.DeleteAsync(id);
    }

    public async Task<List<ResultMatchDto>> TGetMatchesBySeasonAndWeekAsync(int seasonId, int week)
    {
        var matches = await _matchDal.GetMatchesBySeasonAndWeekAsync(seasonId, week);
        return _mapper.Map<List<ResultMatchDto>>(matches);
    }
}
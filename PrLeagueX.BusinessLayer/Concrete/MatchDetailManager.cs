using AutoMapper;
using PrLeagueX.BusinessLayer.Abstract;
using PrLeagueX.DataAccessLayer.Abstract;
using PrLeagueX.DtoLayer.MatchDetailDtos;
using PrLeagueX.Entity.Entities;

namespace PrLeagueX.BusinessLayer.Concrete;

public class MatchDetailManager : IMatchDetailService
{
    private readonly IMatchDetailDal _matchDetailDal;
    private readonly IMapper _mapper;

    public MatchDetailManager(IMatchDetailDal matchDetailDal, IMapper mapper)
    {
        _matchDetailDal = matchDetailDal;
        _mapper = mapper;
    }

    public async Task<List<ResultMatchDetailDto>> TGetListAsync()
    {
        var values = await _matchDetailDal.GetListAsync();
        return _mapper.Map<List<ResultMatchDetailDto>>(values);
    }

    public async Task<UpdateMatchDetailDto> TGetByIdAsync(int id)
    {
        var value = await _matchDetailDal.GetByIdAsync(id);
        return _mapper.Map<UpdateMatchDetailDto>(value);
    }

    public async Task TInsertAsync(CreateMatchDetailDto dto)
    {
        var value = _mapper.Map<MatchDetail>(dto);
        await _matchDetailDal.InsertAsync(value);
    }

    public async Task TUpdateAsync(UpdateMatchDetailDto dto)
    {
        var value = _mapper.Map<MatchDetail>(dto);
        await _matchDetailDal.UpdateAsync(value);
    }

    public async Task TDeleteAsync(int id)
    {
        await _matchDetailDal.DeleteAsync(id);
    }

    public async Task<List<ResultMatchDetailDto>> TGetByMatchIdAsync(int matchId)
    {
        var values = await _matchDetailDal.GetDetailsByMatchIdAsync(matchId);
        return _mapper.Map<List<ResultMatchDetailDto>>(values);
    }
}
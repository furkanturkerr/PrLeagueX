using AutoMapper;
using PrLeagueX.BusinessLayer.Abstract;
using PrLeagueX.DataAccessLayer.Abstract;
using PrLeagueX.DtoLayer.MatchStatisticDtos;
using PrLeagueX.Entity.Entities;

namespace PrLeagueX.BusinessLayer.Concrete;

public class MatchStatisticManager : IMatchStatisticService
{
    private readonly IMatchStatisticDal _matchStatisticDal;
    private readonly IMapper _mapper;

    public MatchStatisticManager(IMatchStatisticDal matchStatisticDal, IMapper mapper)
    {
        _matchStatisticDal = matchStatisticDal;
        _mapper = mapper;
    }

    public async Task<List<ResultMatchStatisticDto>> TGetListAsync()
    {
        var values = await _matchStatisticDal.GetListAsync();
        return _mapper.Map<List<ResultMatchStatisticDto>>(values);
    }

    public async Task<UpdateMatchStatisticDto> TGetByIdAsync(int id)
    {
        var value = await _matchStatisticDal.GetByIdAsync(id);
        return _mapper.Map<UpdateMatchStatisticDto>(value);
    }

    public async Task TInsertAsync(CreateMatchStatisticDto dto)
    {
        var value = _mapper.Map<MatchStatistic>(dto);
        await _matchStatisticDal.InsertAsync(value);
    }

    public async Task TUpdateAsync(UpdateMatchStatisticDto dto)
    {
        var value = _mapper.Map<MatchStatistic>(dto);
        await _matchStatisticDal.UpdateAsync(value);
    }

    public async Task TDeleteAsync(int id)
    {
        await _matchStatisticDal.DeleteAsync(id);
    }

    public async Task<ResultMatchStatisticDto?> TGetByMatchIdAsync(int matchId)
    {
        var value = await _matchStatisticDal.GetStatisticByMatchIdAsync(matchId);
        return _mapper.Map<ResultMatchStatisticDto?>(value);
    }
}
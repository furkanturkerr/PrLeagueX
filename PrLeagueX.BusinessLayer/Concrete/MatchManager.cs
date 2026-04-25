using AutoMapper;
using PrLeagueX.BusinessLayer.Abstract;
using PrLeagueX.DataAccessLayer.Abstract;
using PrLeagueX.DtoLayer.MatchDtos;

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

    public Task<UpdateMatchDto> TGetByIdAsync(int id)
    {
        throw new NotImplementedException();
    }

    public Task TInsertAsync(CreateMatchDto dto)
    {
        throw new NotImplementedException();
    }

    public Task TUpdateAsync(UpdateMatchDto dto)
    {
        throw new NotImplementedException();
    }

    public Task TDeleteAsync(int id)
    {
        throw new NotImplementedException();
    }
}
using AutoMapper;
using PrLeagueX.BusinessLayer.Abstract;
using PrLeagueX.DataAccessLayer.Abstract;
using PrLeagueX.DtoLayer.LeagueDtos;

namespace PrLeagueX.BusinessLayer.Concrete;

public class LeagueManager : ILeagueService
{
    private readonly ILeagueDal _leagueDal;
    private readonly IMapper _mapper;

    public LeagueManager(ILeagueDal leagueDal, IMapper mapper)
    {
        _leagueDal = leagueDal;
        _mapper = mapper;
    }

    public async Task<List<ResultLeagueDto>> TGetListAsync()
    {
        var values = await _leagueDal.GetListAsync();
        return _mapper.Map<List<ResultLeagueDto>>(values);
    }

    public Task<UpdateLeagueDto> TGetByIdAsync(int id)
    {
        throw new NotImplementedException();
    }

    public Task TInsertAsync(CreateLeagueDto dto)
    {
        throw new NotImplementedException();
    }

    public Task TUpdateAsync(UpdateLeagueDto dto)
    {
        throw new NotImplementedException();
    }

    public Task TDeleteAsync(int id)
    {
        throw new NotImplementedException();
    }
}
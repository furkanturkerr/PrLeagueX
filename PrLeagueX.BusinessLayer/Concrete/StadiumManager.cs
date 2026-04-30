using AutoMapper;
using PrLeagueX.BusinessLayer.Abstract;
using PrLeagueX.DataAccessLayer.Abstract;
using PrLeagueX.DtoLayer.StadiumDtos;

namespace PrLeagueX.BusinessLayer.Concrete;

public class StadiumManager : IStadiumService
{
    private readonly IStadiumDal _stadiumDal;
    private readonly IMapper _mapper;

    public StadiumManager(IStadiumDal stadiumDal, IMapper mapper)
    {
        _stadiumDal = stadiumDal;
        _mapper = mapper;
    }

    public async Task<List<ResultStadiumDto>> TGetListAsync()
    {
        var values = await _stadiumDal.GetListAsync();
        return _mapper.Map<List<ResultStadiumDto>>(values);
    }

    public async Task<UpdateStadiumDto> TGetByIdAsync(int id)
    {
        var values = await _stadiumDal.GetByIdAsync(id);
        return _mapper.Map<UpdateStadiumDto>(values);
    }

    public Task TInsertAsync(CreateStadiumDto dto)
    {
        throw new NotImplementedException();
    }

    public Task TUpdateAsync(UpdateStadiumDto dto)
    {
        throw new NotImplementedException();
    }

    public Task TDeleteAsync(int id)
    {
        throw new NotImplementedException();
    }
}
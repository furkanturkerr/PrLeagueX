using AutoMapper;
using PrLeagueX.BusinessLayer.Abstract;
using PrLeagueX.DataAccessLayer.Abstract;
using PrLeagueX.DtoLayer.SeasonDtos;

namespace PrLeagueX.BusinessLayer.Concrete;

public class SeasonManager : ISeasonService
{
    private readonly ISeasonDal _seasonDal;
    private readonly IMapper _mapper;

    public SeasonManager(ISeasonDal seasonDal, IMapper mapper)
    {
        _seasonDal = seasonDal;
        _mapper = mapper;
    }

    public async Task<List<ResultSeasonDto>> TGetListAsync()
    {
        var values = _seasonDal.GetListAsync();
        return _mapper.Map<List<ResultSeasonDto>>(await values);
    }

    public Task<UpdateSeasonDto> TGetByIdAsync(int id)
    {
        throw new NotImplementedException();
    }

    public Task TInsertAsync(CreateSeasonDto dto)
    {
        throw new NotImplementedException();
    }

    public Task TUpdateAsync(UpdateSeasonDto dto)
    {
        throw new NotImplementedException();
    }

    public Task TDeleteAsync(int id)
    {
        throw new NotImplementedException();
    }
}
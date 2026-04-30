using AutoMapper;
using PrLeagueX.BusinessLayer.Abstract;
using PrLeagueX.DataAccessLayer.Abstract;
using PrLeagueX.DtoLayer.SeasonDtos;
using PrLeagueX.Entity.Entities;

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

    public async Task<UpdateSeasonDto> TGetByIdAsync(int id)
    {
        var values = _seasonDal.GetByIdAsync(id);
        return _mapper.Map<UpdateSeasonDto>(await values);
    }

    public async Task TInsertAsync(CreateSeasonDto dto)
    {
        var values = _mapper.Map<Season>(dto);
        await _seasonDal.InsertAsync(values);
    }

    public async Task TUpdateAsync(UpdateSeasonDto dto)
    {
        var values = _mapper.Map<Season>(dto);
        await _seasonDal.UpdateAsync(values);
    }

    public async Task TDeleteAsync(int id)
    {
        await _seasonDal.DeleteAsync(id);
    }
}
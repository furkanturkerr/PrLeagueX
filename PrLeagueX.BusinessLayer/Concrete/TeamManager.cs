using AutoMapper;
using PrLeagueX.BusinessLayer.Abstract;
using PrLeagueX.DataAccessLayer.Abstract;
using PrLeagueX.DtoLayer.TeamDtos;
using PrLeagueX.Entity.Entities;

namespace PrLeagueX.BusinessLayer.Concrete;

public class TeamManager : ITeamService
{
    private readonly ITeamDal _teamDal;
    private readonly IMapper _mapper;

    public TeamManager(ITeamDal teamDal, IMapper mapper)
    {
        _teamDal = teamDal;
        _mapper = mapper;
    }

    public async Task<List<ResultTeamDto>> TGetListAsync()
    {
        var values = await _teamDal.GetListAsync();
        return _mapper.Map<List<ResultTeamDto>>(values);
    }

    public async Task<UpdateTeamDto> TGetByIdAsync(int id)
    {
        var values = await _teamDal.GetByIdAsync(id);
        return _mapper.Map<UpdateTeamDto>(values);
    }

    public async Task TInsertAsync(CreateTeamDto dto)
    {
        var values = _mapper.Map<Team>(dto);
        await _teamDal.InsertAsync(values);
    }

    public async Task TUpdateAsync(UpdateTeamDto dto)
    {
        var values = _mapper.Map<Team>(dto);
        await _teamDal.UpdateAsync(values);
    }

    public async Task TDeleteAsync(int id)
    {
        await _teamDal.DeleteAsync(id);
    }

    public async Task<List<ResultTeamDto>> TGetListWithStadiumsAsync()
    {
        var values = await _teamDal.GetListWithStadiumsAsync();
        return _mapper.Map<List<ResultTeamDto>>(values);
    }
}

using PrLeagueX.DtoLayer.TeamDtos;

namespace PrLeagueX.BusinessLayer.Abstract;

public interface ITeamService : IGenericService<ResultTeamDto, CreateTeamDto, UpdateTeamDto>
{
    Task<List<ResultTeamDto>> TGetListWithStadiumsAsync();

}
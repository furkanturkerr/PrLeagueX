using PrLeagueX.Entity.Entities;

namespace PrLeagueX.DataAccessLayer.Abstract;

public interface ITeamDal : IGenericDal<Team>
{
    Task<List<Team>> GetListWithStadiumsAsync();
}
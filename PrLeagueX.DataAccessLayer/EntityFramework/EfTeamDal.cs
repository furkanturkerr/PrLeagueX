using PrLeagueX.DataAccessLayer.Abstract;
using PrLeagueX.DataAccessLayer.Concrate;
using PrLeagueX.DataAccessLayer.Repository;
using PrLeagueX.Entity.Entities;

namespace PrLeagueX.DataAccessLayer.EntityFramework;

public class EfTeamDal : GenericRepository<Team>, ITeamDal
{
    public EfTeamDal(PrLeagueXContext context) : base(context)
    {
    }
}
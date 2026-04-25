using PrLeagueX.DataAccessLayer.Abstract;
using PrLeagueX.DataAccessLayer.Concrate;
using PrLeagueX.DataAccessLayer.Repository;
using PrLeagueX.Entity.Entities;

namespace PrLeagueX.DataAccessLayer.EntityFramework;

public class EfMatchDetailDal : GenericRepository<MatchDetail>, IMatchDetailDal
{
    public EfMatchDetailDal(PrLeagueXContext context) : base(context)
    {
    }
}
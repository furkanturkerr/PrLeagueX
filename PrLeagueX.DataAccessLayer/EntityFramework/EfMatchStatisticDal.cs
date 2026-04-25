using PrLeagueX.DataAccessLayer.Abstract;
using PrLeagueX.DataAccessLayer.Concrate;
using PrLeagueX.DataAccessLayer.Repository;
using PrLeagueX.Entity.Entities;

namespace PrLeagueX.DataAccessLayer.EntityFramework;

public class EfMatchStatisticDal : GenericRepository<MatchStatistic>, IMatchStatisticDal
{
    public EfMatchStatisticDal(PrLeagueXContext context) : base(context)
    {
    }
}
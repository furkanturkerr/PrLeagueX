using PrLeagueX.DataAccessLayer.Abstract;
using PrLeagueX.DataAccessLayer.Concrate;
using PrLeagueX.DataAccessLayer.Repository;
using PrLeagueX.Entity.Entities;

namespace PrLeagueX.DataAccessLayer.EntityFramework;

public class EfSeasonDal : GenericRepository<Season>, ISeasonDal
{
    public EfSeasonDal(PrLeagueXContext context) : base(context)
    {
    }
}
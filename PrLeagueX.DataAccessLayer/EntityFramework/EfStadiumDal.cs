using PrLeagueX.DataAccessLayer.Abstract;
using PrLeagueX.DataAccessLayer.Concrate;
using PrLeagueX.DataAccessLayer.Repository;
using PrLeagueX.Entity.Entities;

namespace PrLeagueX.DataAccessLayer.EntityFramework;

public class EfStadiumDal : GenericRepository<Stadium>, IStadiumDal
{
    public EfStadiumDal(PrLeagueXContext context) : base(context)
    {
        
    }
}
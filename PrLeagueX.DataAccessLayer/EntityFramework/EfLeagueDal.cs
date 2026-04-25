using PrLeagueX.DataAccessLayer.Abstract;
using PrLeagueX.DataAccessLayer.Concrate;
using PrLeagueX.DataAccessLayer.Repository;
using PrLeagueX.Entity.Entities;

namespace PrLeagueX.DataAccessLayer.EntityFramework;

public class EfLeagueDal : GenericRepository<League>, ILeagueDal
{
    public EfLeagueDal(PrLeagueXContext context) : base(context)
    {
    }
}
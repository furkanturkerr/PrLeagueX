using System.Text.RegularExpressions;
using PrLeagueX.DataAccessLayer.Abstract;
using PrLeagueX.DataAccessLayer.Concrate;
using PrLeagueX.DataAccessLayer.Repository;

namespace PrLeagueX.DataAccessLayer.EntityFramework;

public class EfMatchDal : GenericRepository<Match>, IMatchDal
{
    public EfMatchDal(PrLeagueXContext context) : base(context)
    {
    }
}
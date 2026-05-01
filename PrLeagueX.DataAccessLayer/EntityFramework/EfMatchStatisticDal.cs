using Microsoft.EntityFrameworkCore;
using PrLeagueX.DataAccessLayer.Abstract;
using PrLeagueX.DataAccessLayer.Concrate;
using PrLeagueX.DataAccessLayer.Repository;
using PrLeagueX.Entity.Entities;

namespace PrLeagueX.DataAccessLayer.EntityFramework;

public class EfMatchStatisticDal : GenericRepository<MatchStatistic>, IMatchStatisticDal
{
    private readonly PrLeagueXContext _context;

    public EfMatchStatisticDal(PrLeagueXContext context) : base(context)
    {
        _context = context;
    }

    public async Task<MatchStatistic?> GetStatisticByMatchIdAsync(int matchId)
    {
        return await _context.MatchStatistics
            .Include(x => x.Match)
            .ThenInclude(x => x.HomeTeam)
            .Include(x => x.Match)
            .ThenInclude(x => x.AwayTeam)
            .FirstOrDefaultAsync(x => x.MatchId == matchId);
    }
}
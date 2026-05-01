using Microsoft.EntityFrameworkCore;
using PrLeagueX.DataAccessLayer.Abstract;
using PrLeagueX.DataAccessLayer.Concrate;
using PrLeagueX.DataAccessLayer.Repository;
using PrLeagueX.Entity.Entities;

namespace PrLeagueX.DataAccessLayer.EntityFramework;

public class EfMatchDetailDal : GenericRepository<MatchDetail>, IMatchDetailDal
{
    private readonly PrLeagueXContext _context;

    public EfMatchDetailDal(PrLeagueXContext context) : base(context)
    {
        _context = context;
    }

    public async Task<List<MatchDetail>> GetDetailsByMatchIdAsync(int matchId)
    {
        return await _context.MatchDetails
            .Include(x => x.Team)   
            .Where(x => x.MatchId == matchId)
            .OrderBy(x => x.Minute)
            .ToListAsync();
    }
}
using Microsoft.EntityFrameworkCore;
using PrLeagueX.DataAccessLayer.Abstract;
using PrLeagueX.DataAccessLayer.Concrate;
using PrLeagueX.DataAccessLayer.Repository;
using PrLeagueX.Entity.Entities;
using PrLeagueX.Entity.Enums;

namespace PrLeagueX.DataAccessLayer.EntityFramework;

public class EfMatchDal : GenericRepository<Match>, IMatchDal
{
    private readonly PrLeagueXContext _context;
    public EfMatchDal(PrLeagueXContext context) : base(context)
    {
        _context = context;
    }

    public async Task<List<Match>> GetFinishedMatchesBySeasonAsync(int seasonId)
    {
        return await _context.Matches
            .Where(x => x.SeasonId == seasonId && x.Status == MatchStatus.Finished)
            .ToListAsync();
    }
}
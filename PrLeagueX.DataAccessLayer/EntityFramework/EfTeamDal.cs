using Microsoft.EntityFrameworkCore;
using PrLeagueX.DataAccessLayer.Abstract;
using PrLeagueX.DataAccessLayer.Concrate;
using PrLeagueX.DataAccessLayer.Repository;
using PrLeagueX.Entity.Entities;

namespace PrLeagueX.DataAccessLayer.EntityFramework;

public class EfTeamDal : GenericRepository<Team>, ITeamDal
{
    private readonly PrLeagueXContext _context;
    public EfTeamDal(PrLeagueXContext context) : base(context)
    {
        _context = context;
    }

    public async Task<List<Team>> GetListWithStadiumsAsync()
    {
        var values = await _context.Teams.Include(x => x.Stadium).ToListAsync();
        return values;
    }
}
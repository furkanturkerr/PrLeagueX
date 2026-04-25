using PrLeagueX.BusinessLayer.Abstract;
using PrLeagueX.DataAccessLayer.Abstract;
using PrLeagueX.DtoLayer.StandingDtos;
using PrLeagueX.Entity.Enums;

namespace PrLeagueX.BusinessLayer.Concrete;

public class StandingManager : IStandingService
{
    private readonly ITeamDal _teamDal;
    private readonly IMatchDal _matchDal;

    public StandingManager(ITeamDal teamDal, IMatchDal matchDal)
    {
        _teamDal = teamDal;
        _matchDal = matchDal;
    }

    public async Task<List<ResultStandingDto>> TGetStandingsAsync(int seasonId)
    {
        var teams = await _teamDal.GetListAsync();
        var matches = await _matchDal.GetFinishedMatchesBySeasonAsync(seasonId);

        var standings = teams
            .Where(x => x.IsActive)
            .Select(team => new ResultStandingDto
            {
                TeamId = team.TeamId,
                TeamName = team.TeamName,
                ShortName = team.ShortName,
                LogoUrl = team.LogoUrl,

                Played = 0,
                Won = 0,
                Drawn = 0,
                Lost = 0,
                GoalsFor = 0,
                GoalsAgainst = 0,
                GoalDifference = 0,
                Points = 0,
                Zone = "none"
            })
            .ToList();

        foreach (var match in matches)
        {
            if (match.HomeScore == null || match.AwayScore == null)
                continue;

            var home = standings.FirstOrDefault(x => x.TeamId == match.HomeTeamId);
            var away = standings.FirstOrDefault(x => x.TeamId == match.AwayTeamId);

            if (home == null || away == null)
                continue;

            var homeScore = match.HomeScore.Value;
            var awayScore = match.AwayScore.Value;

            home.Played++;
            away.Played++;

            home.GoalsFor += homeScore;
            home.GoalsAgainst += awayScore;

            away.GoalsFor += awayScore;
            away.GoalsAgainst += homeScore;

            if (homeScore > awayScore)
            {
                home.Won++;
                away.Lost++;
                home.Points += 3;
            }
            else if (awayScore > homeScore)
            {
                away.Won++;
                home.Lost++;
                away.Points += 3;
            }
            else
            {
                home.Drawn++;
                away.Drawn++;
                home.Points += 1;
                away.Points += 1;
            }
        }

        var orderedStandings = standings
            .Select(x =>
            {
                x.GoalDifference = x.GoalsFor - x.GoalsAgainst;
                return x;
            })
            .OrderByDescending(x => x.Points)
            .ThenByDescending(x => x.GoalDifference)
            .ThenByDescending(x => x.GoalsFor)
            .ThenBy(x => x.TeamName)
            .ToList();

        for (int i = 0; i < orderedStandings.Count; i++)
        {
            orderedStandings[i].Position = i + 1;

            orderedStandings[i].Zone = orderedStandings[i].Position switch
            {
                1 => "champ",
                >= 2 and <= 4 => "ucl",
                >= 5 and <= 6 => "uel",
                >= 18 => "rel",
                _ => "none"
            };
        }

        return orderedStandings;
    }
}
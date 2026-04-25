using Microsoft.EntityFrameworkCore;
using PrLeagueX.Entity.Entities;

namespace PrLeagueX.DataAccessLayer.Concrate;

public class PrLeagueXContext : DbContext
{
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer(
            "Server=localhost,1995;Database=PrLeagueX;User Id=sa;Password=Furkan12*;TrustServerCertificate=True;");
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        // Match - HomeTeam ilişkisi
        modelBuilder.Entity<Match>()
            .HasOne(x => x.HomeTeam)
            .WithMany(x => x.HomeMatches)
            .HasForeignKey(x => x.HomeTeamId)
            .OnDelete(DeleteBehavior.Restrict);

        // Match - AwayTeam ilişkisi
        modelBuilder.Entity<Match>()
            .HasOne(x => x.AwayTeam)
            .WithMany(x => x.AwayMatches)
            .HasForeignKey(x => x.AwayTeamId)
            .OnDelete(DeleteBehavior.Restrict);

        // Match - MatchStatistic bire bir ilişki
        modelBuilder.Entity<Match>()
            .HasOne(x => x.MatchStatistic)
            .WithOne(x => x.Match)
            .HasForeignKey<MatchStatistic>(x => x.MatchId)
            .OnDelete(DeleteBehavior.Cascade);

        // Match - MatchDetail bire çok ilişki
        modelBuilder.Entity<Match>()
            .HasMany(x => x.MatchDetails)
            .WithOne(x => x.Match)
            .HasForeignKey(x => x.MatchId)
            .OnDelete(DeleteBehavior.Cascade);
    }

    public DbSet<League> Leagues { get; set; }
    public DbSet<Match> Matches { get; set; }
    public DbSet<Team> Teams { get; set; }
    public DbSet<Stadium> Stadiums { get; set; }
    public DbSet<Season> Seasons { get; set; }
    public DbSet<MatchDetail> MatchDetails { get; set; }
    public DbSet<MatchStatistic> MatchStatistics { get; set; }
}
using LeagueTables.Data.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace LeagueTables.Data.Context;

public class LeagueTablesContext(DbContextOptions options) : IdentityDbContext<UserEntity, IdentityRole<Guid>, Guid>(options)
{
    public DbSet<LeagueEntity> LeagueEntities { get; set; }

    public DbSet<LeagueSeasonEntity> LeagueSeasonEntities { get; set; }

    public DbSet<MatchEntity> MatchEntities { get; set; }

    public DbSet<RoundEntity> RoundEntities { get; set; }

    public DbSet<TeamEntity> TeamEntities { get; set; }

    public DbSet<TeamMatchEntryEntity> TeamMatchEntryEntities { get; set; }

    public DbSet<TeamTableScoreEntity> TeamTableScoreEntities { get; set; }
}

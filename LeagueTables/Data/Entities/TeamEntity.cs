using LeagueTables.Data.EntityConfigurations;
using Microsoft.EntityFrameworkCore;

namespace LeagueTables.Data.Entities;

[EntityTypeConfiguration(typeof(TeamConfiguration))]
public class TeamEntity
{
    public Guid Id { get; set; }

    public string Name { get; set; } = string.Empty;

    public string? Description { get; set; }

    public ICollection<LeagueSeasonEntity> Seasons { get; set; } = new List<LeagueSeasonEntity>();

    public ICollection<TeamMatchEntryEntity> MatchesEntries { get; set; } = new List<TeamMatchEntryEntity>();

    public ICollection<TeamTableScoreEntity> TablesScores { get; set; } = new List<TeamTableScoreEntity>();

    public ICollection<UserEntity> LikedBy { get; set; } = new List<UserEntity>();
}

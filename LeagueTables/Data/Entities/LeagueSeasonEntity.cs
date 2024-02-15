using LeagueTables.Data.EntityConfigurations;
using Microsoft.EntityFrameworkCore;

namespace LeagueTables.Data.Entities;

[EntityTypeConfiguration(typeof(LeagueSeasonConfiguration))]
public class LeagueSeasonEntity
{
    public Guid Id { get; set; }

    public string Name { get; set; } = string.Empty;

    public string? Description { get; set; }

    public Guid LeagueId { get; set; }

    public LeagueEntity League { get; set; } = null!;

    public ICollection<TableEntity> Tables { get; set; } = new List<TableEntity>();

    public ICollection<RoundEntity> Rounds { get; set; } = new List<RoundEntity>();

    public ICollection<TeamEntity> Teams { get; set; } = new List<TeamEntity>();
}

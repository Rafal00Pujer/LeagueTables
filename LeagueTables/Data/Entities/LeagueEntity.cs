using LeagueTables.Data.EntityConfigurations;
using Microsoft.EntityFrameworkCore;

namespace LeagueTables.Data.Entities;

[EntityTypeConfiguration(typeof(LeagueConfiguration))]
public class LeagueEntity
{
    public Guid Id { get; set; }

    public string Name { get; set; } = string.Empty;

    public string? Description { get; set; }

    public ICollection<LeagueSeasonEntity> Seasons { get; set; } = new List<LeagueSeasonEntity>();
}

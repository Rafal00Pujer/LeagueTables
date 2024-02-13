using LeagueTables.Data.EntityConfigurations;
using Microsoft.EntityFrameworkCore;

namespace LeagueTables.Data.Entities;

[EntityTypeConfiguration(typeof(MatchConfiguration))]
public class MatchEntity
{
    public Guid Id { get; set; }

    public DateTime Date { get; set; }

    public Guid RoundId { get; set; }

    public RoundEntity Round { get; set; } = null!;

    public ICollection<TeamMatchEntryEntity> TeamsEntries { get; set; } = new List<TeamMatchEntryEntity>();
}

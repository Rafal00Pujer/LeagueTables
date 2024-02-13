using LeagueTables.Data.EntityConfigurations;
using Microsoft.EntityFrameworkCore;

namespace LeagueTables.Data.Entities;

[EntityTypeConfiguration(typeof(TeamMatchEntryConfiguration))]
public class TeamMatchEntryEntity
{
    public Guid Id { get; set; }

    public int Score { get; set; }

    public Guid TeamId { get; set; }

    public TeamEntity Team { get; set; } = null!;

    public Guid MatchId { get; set; }

    public MatchEntity Match { get; set; } = null!;
}

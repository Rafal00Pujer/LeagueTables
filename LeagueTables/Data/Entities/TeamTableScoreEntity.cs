using LeagueTables.Data.EntityConfigurations;
using Microsoft.EntityFrameworkCore;

namespace LeagueTables.Data.Entities;

[EntityTypeConfiguration(typeof(TeamTableScoreConfiguration))]
public class TeamTableScoreEntity
{
    public Guid Id { get; set; }

    public int MatchesPlayed { get; set; }

    public int Wins { get; set; }

    public int Losses { get; set; }

    public int Draws { get; set; }

    public int GoalsFor { get; set; }

    public int GoalsAgainst { get; set; }

    public int GoalsDifference { get; set; }

    public int Points { get; set; }

    public Guid TeamId { get; set; }

    public TeamEntity Team { get; set; } = null!;

    public Guid TableId { get; set; }

    public TableEntity Table { get; set; } = null!;
}

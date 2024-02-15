using LeagueTables.Data.EntityConfigurations;
using Microsoft.EntityFrameworkCore;

namespace LeagueTables.Data.Entities;

[EntityTypeConfiguration(typeof(TableConfiguration))]
public class TableEntity
{
    public Guid Id { get; set; }

    public string Name { get; set; }

    public Guid SeasonId { get; set; }

    public LeagueSeasonEntity Season { get; set; } = null!;

    public ICollection<RoundEntity> Rounds { get; set; } = new List<RoundEntity>();

    public ICollection<TeamTableScoreEntity> TableScores { get; set; } = new List<TeamTableScoreEntity>();
}

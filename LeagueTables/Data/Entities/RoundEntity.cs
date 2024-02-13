using LeagueTables.Data.EntityConfigurations;
using Microsoft.EntityFrameworkCore;

namespace LeagueTables.Data.Entities;

[EntityTypeConfiguration(typeof(RoundConfiguration))]
public class RoundEntity
{
    public Guid Id { get; set; }

    public int RoundNumber { get; set; }

    public string? Name { get; set; }

    public Guid SeasonId { get; set; }

    public LeagueSeasonEntity Season { get; set; } = null!;

    public ICollection<MatchEntity> Matches { get; set; } = new List<MatchEntity>();
}

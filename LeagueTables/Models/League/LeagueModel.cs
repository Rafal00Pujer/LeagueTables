using LeagueTables.Models.LeagueSeason;
using System.ComponentModel.DataAnnotations;

namespace LeagueTables.Models.League;

public class LeagueModel
{
    public Guid Id { get; set; }

    public string Name { get; set; }

    public string? Description { get; set; }

    public ICollection<LeagueSeasonBasicModel> Seasons { get; set; } = new List<LeagueSeasonBasicModel>();
}

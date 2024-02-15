using LeagueTables.Models.Table;

namespace LeagueTables.Models.LeagueSeason;

public class LeagueSeasonTablesModel
{
    public Guid Id { get; set; }

    public string Name { get; set; } = string.Empty;

    public string? Description { get; set; }

    public string LeagueName { get; set; } = string.Empty;

    public ICollection<TableScoresModel> Tables { get; set; } = new List<TableScoresModel>();
}

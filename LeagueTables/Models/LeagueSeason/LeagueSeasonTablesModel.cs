using LeagueTables.Models.Table;

namespace LeagueTables.Models.LeagueSeason;

public class LeagueSeasonTablesModel
{
    public Guid Id { get; set; }

    public string Name { get; set; }

    public string Description { get; set; }

    public string LeagueName { get; set; }

    public ICollection<TableModel> Tables { get; set; } = new List<TableModel>();
}

using LeagueTables.Models.Team;

namespace LeagueTables.Models.Table;

public class TableScoresModel
{
    public Guid Id { get; set; }

    public string Name { get; set; } = string.Empty;

    public ICollection<TeamTableScoreModel> TableScores { get; set; } = new List<TeamTableScoreModel>();
}

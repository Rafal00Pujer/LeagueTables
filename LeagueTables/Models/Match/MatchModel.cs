using LeagueTables.Models.Team;

namespace LeagueTables.Models.Match;

public class MatchModel
{
    public Guid Id { get; set; }

    public DateTime Date { get; set; }

    public ICollection<TeamMatchScoreModel> Scores { get; set; } = new List<TeamMatchScoreModel>();
}

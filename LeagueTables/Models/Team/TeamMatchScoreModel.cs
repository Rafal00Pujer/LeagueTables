namespace LeagueTables.Models.Team;

public class TeamMatchScoreModel
{
    public Guid Id { get; set; }

    public int Score { get; set; }

    public string TeamName { get; set; } = string.Empty;
}

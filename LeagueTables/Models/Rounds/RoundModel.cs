using LeagueTables.Models.Match;

namespace LeagueTables.Models.Rounds;

public class RoundModel
{
    public Guid Id { get; set; }

    public int RoundNumber { get; set; }

    public string? Name { get; set; }

    public ICollection<MatchModel> Matches { get; set; } = new List<MatchModel>();
}

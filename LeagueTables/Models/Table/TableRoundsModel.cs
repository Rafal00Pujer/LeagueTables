using LeagueTables.Models.Rounds;

namespace LeagueTables.Models.Table;

public class TableRoundsModel
{
    public Guid Id { get; set; }

    public string TableName { get; set; } = string.Empty;

    public ICollection<RoundModel> Rounds { get; set; } = new List<RoundModel>();
}

using LeagueTables.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LeagueTables.Data.EntityConfigurations;

public class TeamTableScoreConfiguration : IEntityTypeConfiguration<TeamTableScoreEntity>
{
    public void Configure(EntityTypeBuilder<TeamTableScoreEntity> builder)
    {
        builder.ToTable("TeamTableScore");

        builder.HasKey(e => e.Id);

        builder.HasOne(e => e.Team)
            .WithMany(fe => fe.TablesScores)
            .HasForeignKey(e => e.TeamId)
            .HasPrincipalKey(fe => fe.Id)
            .OnDelete(DeleteBehavior.NoAction);

        builder.HasOne(e => e.Season)
            .WithMany(fe => fe.TeamsScores)
            .HasForeignKey(e => e.SeasonId)
            .HasPrincipalKey(fe => fe.Id)
            .OnDelete(DeleteBehavior.NoAction);

        builder.Property(e => e.GoalsDifference)
            .HasComputedColumnSql("[GoalsFor] - [GoalsAgainst]");

        builder.Property(e => e.Points)
            .HasComputedColumnSql("[Wins] * 3 + [Draws]");
    }
}

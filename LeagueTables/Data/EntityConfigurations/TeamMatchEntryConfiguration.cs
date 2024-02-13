using LeagueTables.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LeagueTables.Data.EntityConfigurations;

public class TeamMatchEntryConfiguration : IEntityTypeConfiguration<TeamMatchEntryEntity>
{
    public void Configure(EntityTypeBuilder<TeamMatchEntryEntity> builder)
    {
        builder.ToTable("TeamMatchEntry");

        builder.HasKey(e => e.Id);

        builder.HasOne(e => e.Team)
            .WithMany(fe => fe.MatchesEntries)
            .HasForeignKey(e => e.TeamId)
            .HasPrincipalKey(fe => fe.Id)
            .OnDelete(DeleteBehavior.NoAction);

        builder.HasOne(e => e.Match)
            .WithMany(fe => fe.TeamsEntries)
            .HasForeignKey(e => e.MatchId)
            .HasPrincipalKey(fe => fe.Id)
            .OnDelete(DeleteBehavior.NoAction);
    }
}

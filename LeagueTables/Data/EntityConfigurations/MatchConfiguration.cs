using LeagueTables.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LeagueTables.Data.EntityConfigurations;

public class MatchConfiguration : IEntityTypeConfiguration<MatchEntity>
{
    public void Configure(EntityTypeBuilder<MatchEntity> builder)
    {
        builder.ToTable("Match");

        builder.HasKey(e => e.Id);

        builder.HasOne(e => e.Round)
            .WithMany(fe => fe.Matches)
            .HasForeignKey(e => e.RoundId)
            .HasPrincipalKey(fe => fe.Id)
            .OnDelete(DeleteBehavior.NoAction);
    }
}

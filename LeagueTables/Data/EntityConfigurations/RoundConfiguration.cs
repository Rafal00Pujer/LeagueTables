using LeagueTables.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LeagueTables.Data.EntityConfigurations;

public class RoundConfiguration : IEntityTypeConfiguration<RoundEntity>
{
    public void Configure(EntityTypeBuilder<RoundEntity> builder)
    {
        builder.ToTable("Round");

        builder.HasKey(e => e.Id);

        builder.HasOne(e => e.Table)
            .WithMany(fe => fe.Rounds)
            .HasForeignKey(e => e.TableId)
            .HasPrincipalKey(fe => fe.Id)
            .OnDelete(DeleteBehavior.NoAction);
    }
}

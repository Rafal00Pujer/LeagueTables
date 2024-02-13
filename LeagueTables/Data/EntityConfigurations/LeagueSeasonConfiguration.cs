using LeagueTables.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LeagueTables.Data.EntityConfigurations;

public class LeagueSeasonConfiguration : IEntityTypeConfiguration<LeagueSeasonEntity>
{
    public void Configure(EntityTypeBuilder<LeagueSeasonEntity> builder)
    {
        builder.ToTable("LeagueSeason");

        builder.HasKey(e => e.Id);

        builder.HasOne(e => e.League)
            .WithMany(fe => fe.Seasons)
            .HasForeignKey(e => e.LeagueId)
            .HasPrincipalKey(ef => ef.Id);

        builder.HasMany(e => e.Teams)
            .WithMany(fe => fe.Seasons);
    }
}

using LeagueTables.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LeagueTables.Data.EntityConfigurations;

public class LeagueConfiguration : IEntityTypeConfiguration<LeagueEntity>
{
    public void Configure(EntityTypeBuilder<LeagueEntity> builder)
    {
        builder.ToTable("League");

        builder.HasKey(e => e.Id);
    }
}

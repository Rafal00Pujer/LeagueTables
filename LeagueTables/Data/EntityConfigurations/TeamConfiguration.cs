using LeagueTables.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LeagueTables.Data.EntityConfigurations;

public class TeamConfiguration : IEntityTypeConfiguration<TeamEntity>
{
    public void Configure(EntityTypeBuilder<TeamEntity> builder)
    {
        builder.ToTable("Team");

        builder.HasKey(e => e.Id);
    }
}

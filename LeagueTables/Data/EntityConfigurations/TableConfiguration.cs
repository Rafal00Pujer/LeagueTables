using LeagueTables.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LeagueTables.Data.EntityConfigurations;

public class TableConfiguration : IEntityTypeConfiguration<TableEntity>
{
    public void Configure(EntityTypeBuilder<TableEntity> builder)
    {
        builder.ToTable("Table");

        builder.HasKey(e => e.Id);

        builder.HasOne(e => e.Season)
            .WithMany(fe => fe.Tables)
            .HasForeignKey(e => e.SeasonId)
            .HasPrincipalKey(fe => fe.Id)
            .OnDelete(DeleteBehavior.NoAction);
    }
}

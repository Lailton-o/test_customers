using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Test.Domain.Entities;

namespace Test.Infra.Mappings
{
    public class RegionMap : IEntityTypeConfiguration<Region>
    {
        public void Configure(EntityTypeBuilder<Region> builder)
        {
            builder.HasKey(p => p.Id);

            builder.Property(p => p.Name)
                .HasMaxLength(20)
                .HasColumnType("varchar")
                .IsRequired(true);

            builder.ToTable("Region");
        }
    }
}

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Test.Domain.Entities;

namespace Test.Infra.Mappings
{
    public class CityMap : IEntityTypeConfiguration<City>
    {
        public void Configure(EntityTypeBuilder<City> builder)
        {
            builder.HasKey(p => p.Id);

            builder.Property(p => p.Name)
                .HasMaxLength(20)
                .HasColumnType("varchar")
                .IsRequired(true);

            builder.Property(p => p.RegionId)
                .HasColumnType("int")
                .IsRequired(true);

            builder.HasOne(p => p.Region)
                .WithMany()
                .HasForeignKey(p => p.RegionId);

            builder.ToTable("City");

        }
    }
}

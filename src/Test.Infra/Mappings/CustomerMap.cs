using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Test.Domain.Entities;

namespace Test.Infra.Mappings
{
    public class CustomerMap : IEntityTypeConfiguration<Customer>
    {
        public void Configure(EntityTypeBuilder<Customer> builder)
        {
            builder.HasKey(p => p.Id);

            builder.Property(p => p.Name)
                .HasMaxLength(50)
                .HasColumnType("varchar")
                .IsRequired(true);

            builder.Property(p => p.Phone)
                .HasMaxLength(50)
                .HasColumnType("varchar")
                .IsRequired(true);

            builder.Property(p => p.GenderId)
                .IsRequired(true);

            builder.Property(p => p.CityId)
                .IsRequired(false);

            builder.Property(p => p.RegionId)
                .IsRequired(false);

            builder.Property(p => p.LastPurchase)
                .HasColumnType("date")
                .IsRequired(false);

            builder.Property(p => p.ClassificationId)
                .IsRequired(false);

            builder.Property(p => p.UserId)
                .IsRequired(false);

            builder.HasOne(p => p.Gender)
                .WithMany()
                .HasForeignKey(p => p.GenderId);

            builder.HasOne(p => p.City)
                .WithMany()
                .HasForeignKey(p => p.CityId);

            builder.HasOne(p => p.Region)
                .WithMany()
                .HasForeignKey(p => p.RegionId);

            builder.HasOne(p => p.User)
                .WithMany()
                .HasForeignKey(p => p.UserId);

            builder.ToTable("Customer");
        }
    }
}

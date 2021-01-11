using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Test.Domain.Entities;

namespace Test.Infra.Mappings
{
    public class UserRoleMap : IEntityTypeConfiguration<UserRole>
    {
        public void Configure(EntityTypeBuilder<UserRole> builder)
        {
            builder.HasKey(p => p.Id);

            builder.Property(p => p.Name)
                .HasMaxLength(20)
                .HasColumnType("varchar")
                .IsRequired(true);

            builder.Property(p => p.IsAdmin)
                .HasColumnType("bit")
                .IsRequired(true);

            builder.ToTable("UserRole");
        }
    }
}

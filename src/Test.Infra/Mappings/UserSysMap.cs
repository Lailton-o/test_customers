using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Test.Domain.Entities;

namespace Test.Infra.Mappings
{
    public class UserSysMap : IEntityTypeConfiguration<UserSys>
    {
        public void Configure(EntityTypeBuilder<UserSys> builder)
        {
            builder.HasKey(p => p.Id);

            builder.Property(p => p.Email)
                .HasMaxLength(50)
                .HasColumnType("varchar")
                .IsRequired(true);

            builder.Property(p => p.Login)
                .HasMaxLength(20)
                .HasColumnType("varchar")
                .IsRequired(true);

            builder.Property(p => p.Password)
                .HasMaxLength(40)
                .HasColumnType("varchar")
                .IsRequired(true);

            builder.Property(p => p.UserRoleId)
                .IsRequired(true);

            builder.HasOne(p => p.UserRole)
                .WithMany()
                .HasForeignKey(p => p.UserRoleId);

            builder.ToTable("UserSys");
        }
    }
}

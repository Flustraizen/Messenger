using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Database
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable("Users").HasKey(u => u.Id);
            builder
                .Property(u => u.Name)
                .HasColumnType("varchar(50)")
                .HasMaxLength(50)
                .HasComputedColumnSql("[FirstName] + ' ' + [LastName]");
            builder
                .Property(u => u.FirstName)
                .HasMaxLength(20)
                .HasColumnType("varchar(20)")
                .IsRequired();
            builder
                .Property(u => u.LastName)
                .HasMaxLength(20)
                .HasColumnType("varchar(20)")
                .IsRequired();
        }
    }
}
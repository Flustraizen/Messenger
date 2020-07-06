using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Database
{
    public class MessageConfiguration : IEntityTypeConfiguration<Message>
    {
        public void Configure(EntityTypeBuilder<Message> builder)
        {
            builder.ToTable("Messages").HasKey(m => m.Id);
            builder
                .Property(m => m.Receiver)
                .IsRequired();
            builder
                .Property(m => m.Sender)
                .IsRequired();
        }
    }
}
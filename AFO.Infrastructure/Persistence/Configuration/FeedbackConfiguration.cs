using AFO.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AFO.Infrastructure.Persistence.Configuration
{
    public class FeedbackConfiguration : IEntityTypeConfiguration<Feedback>
    {
        public void Configure(EntityTypeBuilder<Feedback> builder)
        {
            builder.ToTable("Feedbacks");

            builder.HasKey(f => f.Id);

            builder.Property(f => f.Username)
                .IsRequired()
                .HasMaxLength(150);

            builder.Property(f => f.Role)
                .HasMaxLength(150);

            builder.Property(f => f.Message)
                .IsRequired()
                .HasColumnType("text");

            builder.Property(f => f.Image)
                .HasMaxLength(500);

            builder.Property(f => f.Note)
                .HasField("_note")
                .UsePropertyAccessMode(PropertyAccessMode.Field)
                .HasPrecision(2, 1);

            builder.HasOne(f => f.Service)
                .WithMany()
                .HasForeignKey(f => f.ServiceId)
                .OnDelete(DeleteBehavior.SetNull);
        }
    }
}

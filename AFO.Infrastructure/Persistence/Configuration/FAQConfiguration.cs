using AFO.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AFO.Infrastructure.Persistence.Configuration
{
    public class FAQConfiguration : IEntityTypeConfiguration<FAQ>
    {
        public void Configure(EntityTypeBuilder<FAQ> builder)
        {
            builder.ToTable("FAQs");

            builder.HasKey(f => f.Id);

            builder.Property(f => f.Question)
                .IsRequired()
                .HasColumnType("text");

            builder.Property(f => f.Answer)
                .IsRequired()
                .HasColumnType("text");

            builder.HasOne(f => f.Service)
                .WithMany(s => s.FAQs)
                .HasForeignKey(f => f.ServiceId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}

using AFO.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AFO.Infrastructure.Persistence.Configuration
{
    public class BlogConfiguration : IEntityTypeConfiguration<Blog>
    {
        public void Configure(EntityTypeBuilder<Blog> builder)
        {
            builder.ToTable("Blogs");

            builder.HasKey(b => b.Id);

            builder.Property(b => b.Title)
                .IsRequired()
                .HasMaxLength(200);

            builder.Property(b => b.Description)
                .IsRequired()
                .HasColumnType("text");

            builder.Property(b => b.Subtitle)
                .IsRequired()
                .HasColumnType("text");

            builder.Property(b => b.Image)
                .HasMaxLength(500);

            builder.Property(b => b.PublishDate)
                .IsRequired();

            builder.HasOne(b => b.Service)
                .WithMany()
                .HasForeignKey(b => b.ServiceId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasMany(b => b.Articles)
                .WithOne(a => a.Blog)
                .HasForeignKey(a => a.BlogId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}

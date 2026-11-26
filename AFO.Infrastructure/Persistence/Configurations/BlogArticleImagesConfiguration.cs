using AFO.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AFO.Infrastructure.Persistence.Configuration
{
    public class BlogArticleImagesConfiguration 
        : IEntityTypeConfiguration<BlogArticleImages>
    {
        public void Configure(EntityTypeBuilder<BlogArticleImages> builder)
        {
            builder.ToTable("BlogArticleImages");

            builder.HasKey(i => i.Id);

            builder.Property(i => i.Url)
                .IsRequired()
                .HasMaxLength(500);

            builder.HasOne(i => i.BlogArticle)
                .WithMany(a => a.Images)
                .HasForeignKey(i => i.BlogArticleId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}

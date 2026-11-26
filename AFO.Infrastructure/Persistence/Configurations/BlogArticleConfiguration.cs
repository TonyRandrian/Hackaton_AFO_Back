using AFO.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AFO.Infrastructure.Persistence.Configuration
{
    public class BlogArticleConfiguration 
        : IEntityTypeConfiguration<BlogArticle>
    {
        public void Configure(EntityTypeBuilder<BlogArticle> builder)
        {
            builder.ToTable("BlogArticles");

            builder.HasKey(a => a.Id);

            builder.Property(a => a.Title)
                .IsRequired()
                .HasColumnType("text");

            builder.Property(a => a.Content)
                .IsRequired()
                .HasColumnType("text");

            builder.HasOne(a => a.Blog)
                .WithMany(b => b.Articles)
                .HasForeignKey(a => a.BlogId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasMany(a => a.Images)
                .WithOne(i => i.BlogArticle)
                .HasForeignKey(i => i.BlogArticleId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}

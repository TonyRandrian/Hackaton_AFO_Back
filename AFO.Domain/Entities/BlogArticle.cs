namespace AFO.Domain.Entities
{
    public class BlogArticle
    {
        public Guid Id { get; set; }
        public required string Title { get; set; }
        public required string Content { get; set; }
        public Guid BlogId { get; set; }
        public Blog Blog { get; set; } = null!;
        public ICollection<BlogArticleImages> Images { get; set; } = [];
    }
}

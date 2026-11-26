namespace AFO.Domain.Entities
{
    public class BlogArticleImages
    {
        public Guid Id { get; set; }
        public required string Url { get; set; }
        public Guid BlogArticleId { get; set; }
        public BlogArticle BlogArticle { get; set; } = null!;
    }
}

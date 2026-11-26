using AFO.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace AFO.Infrastructure.Persistence
{
    public class AfoDbContext(DbContextOptions<AfoDbContext> options)
        : DbContext(options)
    {

        public DbSet<Service> Services => Set<Service>();
        public DbSet<Processus> Processus => Set<Processus>();
        public DbSet<ServiceContent> ServiceContents => Set<ServiceContent>();
        public DbSet<ServiceExpertise> ServiceExpertises => Set<ServiceExpertise>();
        public DbSet<ServiceProcessus> ServiceProcessus => Set<ServiceProcessus>();
        public DbSet<FAQ> FAQs => Set<FAQ>();
        public DbSet<Feedback> Feedbacks => Set<Feedback>();
        public DbSet<Pricing> Pricings => Set<Pricing>();
        public DbSet<Realization> Realizations => Set<Realization>();
        public DbSet<Advantage> Advantages => Set<Advantage>();
        public DbSet<RealizationAdvantage> RealizationAdvantages => Set<RealizationAdvantage>();
        public DbSet<Technology> Technologies => Set<Technology>();
        public DbSet<RealizationTechnology> RealizationTechnologies => Set<RealizationTechnology>();
        public DbSet<RealizationProcessus> RealizationProcessus => Set<RealizationProcessus>();
        public DbSet<RealizationImage> RealizationImages => Set<RealizationImage>();
        public DbSet<RealizationImageType> RealizationImageTypes => Set<RealizationImageType>();
        public DbSet<Blog> Blogs => Set<Blog>();
        public DbSet<BlogArticle> BlogArticles => Set<BlogArticle>();
        public DbSet<BlogArticleImages> BlogArticleImages => Set<BlogArticleImages>();
        public DbSet<Partner> Partners => Set<Partner>();
        public DbSet<ClientsRequests> ClientsRequests => Set<ClientsRequests>();
        public DbSet<CompanyInformations> CompanyInformations => Set<CompanyInformations>();


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfigurationsFromAssembly(
                typeof(AfoDbContext).Assembly
            );
        }
    }
}

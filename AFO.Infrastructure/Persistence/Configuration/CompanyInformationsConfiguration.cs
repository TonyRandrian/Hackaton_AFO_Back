using AFO.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AFO.Infrastructure.Persistence.Configuration
{
    public class CompanyInformationsConfiguration 
        : IEntityTypeConfiguration<CompanyInformations>
    {
        public void Configure(EntityTypeBuilder<CompanyInformations> builder)
        {
            builder.ToTable("CompanyInformations");

            builder.HasKey(ci => ci.Id);

            builder.Property(ci => ci.Infos)
                .IsRequired()
                .HasMaxLength(500);

            builder.Property(ci => ci.Value)
                .IsRequired()
                .HasColumnType("text");
        }
    }
}

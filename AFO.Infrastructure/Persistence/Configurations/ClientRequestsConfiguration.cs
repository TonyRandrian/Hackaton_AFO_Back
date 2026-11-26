using AFO.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AFO.Infrastructure.Persistence.Configuration
{
    public class ClientRequestsConfiguration 
        : IEntityTypeConfiguration<ClientsRequests>
    {
        public void Configure(EntityTypeBuilder<ClientsRequests> builder)
        {
            builder.ToTable("ClientsRequests");

            builder.HasKey(cr => cr.Id);

            builder.Property(cr => cr.Email)
                .IsRequired()
                .HasMaxLength(254);

            builder.Property(cr => cr.PhoneNumber)
                .IsRequired()
                .HasMaxLength(50);

            builder.Property(cr => cr.Objet)
                .HasMaxLength(300);

            builder.Property(cr => cr.Message)
                .IsRequired()
                .HasColumnType("text");
        }
    }
}

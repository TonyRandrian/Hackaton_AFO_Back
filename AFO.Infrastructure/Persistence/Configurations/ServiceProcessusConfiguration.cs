using AFO.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AFO.Infrastructure.Persistence.Configuration
{
    public class ServiceProcessusConfiguration : IEntityTypeConfiguration<ServiceProcessus>
    {
        public void Configure(EntityTypeBuilder<ServiceProcessus> builder)
        {
            builder.ToTable("ServiceProcessus");

            builder.HasKey(sp => new { sp.ServiceId, sp.ProcessusId });

            builder.HasOne(sp => sp.Service)
                .WithMany(s => s.ServiceProcessus)
                .HasForeignKey(sp => sp.ServiceId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(sp => sp.Processus)
                .WithMany(p => p.ServiceProcessus)
                .HasForeignKey(sp => sp.ProcessusId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}

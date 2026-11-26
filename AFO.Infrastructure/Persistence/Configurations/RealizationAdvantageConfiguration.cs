using AFO.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace AFO.Infrastructure.Persistence.Configuration
{
    public class RealizationAdvantageConfiguration : IEntityTypeConfiguration<RealizationAdvantage>
    {
        public void Configure(EntityTypeBuilder<RealizationAdvantage> builder)
        {
            builder.ToTable("RealizationAdvantages");

            builder.HasKey(ra => new { ra.RealizationId, ra.AdvantageId });
        }
    }
}

using AFO.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace AFO.Infrastructure.Persistence.Configuration
{
    public class RealizationTechnologyConfiguration : IEntityTypeConfiguration<RealizationTechnology>
    {
        public void Configure(EntityTypeBuilder<RealizationTechnology> builder)
        {
            builder.ToTable("RealizationTechnologies");

            builder.HasKey(rt => new { rt.RealizationId, rt.TechnologyId });
        }
    }
}

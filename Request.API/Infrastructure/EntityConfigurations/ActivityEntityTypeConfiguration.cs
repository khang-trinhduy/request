using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Request.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Request.API.Infrastructure.EntityConfigurations
{
    public class ActivityEntityTypeConfiguration : IEntityTypeConfiguration<Activity>
    {
        public void Configure(EntityTypeBuilder<Activity> builder)
        {
            builder.HasKey(e => e.Id);
            builder.HasMany(e => e.Roles).WithOne(e => e.Activity)
                .OnDelete(DeleteBehavior.ClientSetNull);
            builder.HasMany(e => e.Data).WithOne(e => e.Activity)
                .OnDelete(DeleteBehavior.ClientSetNull);
            builder.HasDiscriminator<string>("Discriminator")
            .HasValue<TLActivityOperator>("TALENT-LEAVE")
            .HasValue<ActivityAdapter>("ADAPTER")
            .HasValue<EmailActivityOperator>("EMAIL")
            .HasValue<GenericActivityOperator>("GENERIC")
            .HasValue<CampaignActivityOperator>("CAMPAIGN");
        }
    }
}

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Request.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Request.API.Infrastructure.EntityConfigurations
{
    public class DataEntityTypeConfiguration : IEntityTypeConfiguration<Data>
    {
        public void Configure(EntityTypeBuilder<Data> builder)
        {
            builder.HasKey(e => e.Id);
            builder.HasDiscriminator<string>("Discriminator")
            .HasValue<TLeave>("TALENT-LEAVE")
            .HasValue<Email>("EMAIL")
            .HasValue<Comment>("COMMENT")
            .HasValue<Campaign>("CAMPAIGN")
            .HasValue<Contact>("CONTACT");
        }
    }
}

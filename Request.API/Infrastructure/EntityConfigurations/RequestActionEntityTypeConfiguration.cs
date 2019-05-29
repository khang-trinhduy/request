using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Request.API.Model;
using Request.API.Models;

namespace Request.API.Infrastructure
{
    public class RequestActionEntityTypeConfiguration : IEntityTypeConfiguration<RequestAction>
    {
        public void Configure(EntityTypeBuilder<RequestAction> builder)
        {
            builder.HasKey(k => k.Id);
        }
    }
}
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Request.API.Models;

namespace Request.API.Infrastructure
{
    public class NodeEntityTypeConfiguration : IEntityTypeConfiguration<Node>
    {
        public void Configure(EntityTypeBuilder<Node> builder)
        {
            builder.HasKey(e => e.Id);
            builder.HasMany(e => e.Activities).WithOne(e => e.Node)
                .IsRequired(false).OnDelete(DeleteBehavior.ClientSetNull);
            builder.HasMany(e => e.Actions).WithOne(e => e.Node)
                .IsRequired(false).OnDelete(DeleteBehavior.ClientSetNull);
            builder.HasMany(e => e.Roles).WithOne(e => e.Node)
                .IsRequired(false).OnDelete(DeleteBehavior.ClientSetNull);
        }
    }
}
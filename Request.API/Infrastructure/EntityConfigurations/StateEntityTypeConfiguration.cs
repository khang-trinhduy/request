using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Request.API.Models;

namespace Request.API.Infrastructure
{
    public class StateEntityTypeConfiguration : IEntityTypeConfiguration<State>
    {
        public void Configure(EntityTypeBuilder<State> builder)
        {
            builder.HasKey(e => e.Id);
            builder.HasMany(e => e.Activities).WithOne(e => e.State)
                .IsRequired(false).OnDelete(DeleteBehavior.ClientSetNull);
            builder.HasMany(e => e.Roles).WithOne(e => e.State)
                .IsRequired(false).OnDelete(DeleteBehavior.ClientSetNull);
                
        }
    }
}
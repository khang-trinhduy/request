using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Request.API.Model;
using Request.API.Models;

namespace Request.API.Infrastructure
{
    public class ProcessEntityTypeConfiguration : IEntityTypeConfiguration<Process>
    {
        public void Configure(EntityTypeBuilder<Process> builder)
        {
            builder.HasKey(e => e.Id);
            builder.HasMany(e => e.Actions).WithOne(e => e.Process)
                .IsRequired().OnDelete(DeleteBehavior.Cascade);
            builder.HasMany(e => e.Activities).WithOne(e => e.Process)
                .IsRequired().OnDelete(DeleteBehavior.Cascade);
            builder.HasMany(e => e.Roles).WithOne(e => e.Process);
            builder.HasMany(e => e.Rules).WithOne(e => e.Process)
                .IsRequired().OnDelete(DeleteBehavior.Cascade);
            builder.HasMany(e => e.States).WithOne(e => e.Process)
                .IsRequired().OnDelete(DeleteBehavior.Cascade);
            builder.HasMany(e => e.Nodes).WithOne(e => e.Process)
                .IsRequired().OnDelete(DeleteBehavior.Cascade);
        }
    }
}
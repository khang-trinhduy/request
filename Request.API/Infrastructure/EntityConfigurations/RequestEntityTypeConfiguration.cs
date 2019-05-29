using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Request.API.Infrastructure.EntityConfigurations
{
    public class RequestEntityTypeConfiguration : IEntityTypeConfiguration<Model.Request>
    {
        public void Configure(EntityTypeBuilder<Model.Request> builder)
        {
            builder.HasKey(e => e.Id);
            builder.HasMany(e => e.Histories).WithOne(e =>
            e.Request).IsRequired().OnDelete(DeleteBehavior.Cascade);
            builder.HasMany(e => e.Tasks).WithOne(e =>
            e.Request).IsRequired().OnDelete(DeleteBehavior.Cascade);
            builder.HasMany(e => e.Data).WithOne(e =>
            e.Request).IsRequired().OnDelete(DeleteBehavior.ClientSetNull);
            builder.HasOne(e => e.CurrentState);
            builder.HasOne(e => e.CurrentNode);
        }
    }
}
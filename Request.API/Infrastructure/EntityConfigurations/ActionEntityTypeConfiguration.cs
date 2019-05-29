using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Request.API.Infrastructure.EntityConfigurations
{
    public class ActionEntityTypeConfiguration : IEntityTypeConfiguration<Models.Action>
    {
        public void Configure(EntityTypeBuilder<Models.Action> builder)
        {
            builder.HasKey(e => e.Id);
        }
    }
}

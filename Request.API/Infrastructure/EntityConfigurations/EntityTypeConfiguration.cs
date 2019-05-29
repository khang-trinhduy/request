using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Request.API.Model;
using Request.API.Models;

namespace Request.API.Infrastructure
{
    public class ActionEntityTypeConfiguration : IEntityTypeConfiguration<Action>
    {
        public void Configure(EntityTypeBuilder<Action> builder)
        {
            builder.HasKey(e => e.Id);
        }
    }
}
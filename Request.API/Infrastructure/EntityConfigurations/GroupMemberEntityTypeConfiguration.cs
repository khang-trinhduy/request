using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Request.API.Model;
using Request.API.Models;

namespace Request.API.Infrastructure
{
    public class GroupMemberEntityTypeConfiguration : IEntityTypeConfiguration<GroupMember>
    {
        public void Configure(EntityTypeBuilder<GroupMember> builder)
        {
            builder.HasKey(k => new { k.UserID, k.GroupID});
        }
    }
}
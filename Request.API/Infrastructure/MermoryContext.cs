using Microsoft.EntityFrameworkCore;
using Request.API.Models;

namespace Request.API.Infrastructure
{
    public class MemoryContext : DbContext
    {
        public MemoryContext(DbContextOptions<MemoryContext> options) : base(options) {

        }

        public DbSet<Node> Nodes {get; set;}

    }
}
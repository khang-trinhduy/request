using Request.API.Model;
using Microsoft.EntityFrameworkCore;
using Request.API.Infrastructure.EntityConfigurations;
using Request.API.Models;

namespace Request.API.Infrastructure
{
    public class RequestContext : DbContext
    {
        public DbSet<Model.Request> Requests { get; set; }

        public DbSet<State> States { get; set; }

        public DbSet<Process> Processes { get; set; }

        public DbSet<Activity> Activities { get; set; }

        public DbSet<Role> Roles { get; set; }

        public DbSet<TransitionRule> Rules { get; set; }

        public DbSet<Data> Data { get; set; }

        public DbSet<Task> Tasks { get; set; }

        public DbSet<Action> Actions { get; set; }

        public DbSet<EmailActivityOperator> EmailActivityOperators { get; set; }
        public DbSet<ActivityAdapter> ActivityAdapters { get; set; } 
        public DbSet<Email> Emails { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<TLeave> TalentLeaves { get; set; }
        public DbSet<Campaign> Campaigns { get; set; }

        public DbSet<TLActivityOperator> TL {get; set;}

        public DbSet<EmailSender> EmailSenders { get; set; }
        public DbSet<Node> Nodes { get; set; }

        public RequestContext(DbContextOptions<RequestContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new RequestEntityTypeConfiguration());
            modelBuilder.ApplyConfiguration(new StateEntityTypeConfiguration());
            modelBuilder.ApplyConfiguration(new ProcessEntityTypeConfiguration());
            modelBuilder.ApplyConfiguration(new ActivityEntityTypeConfiguration());
            modelBuilder.ApplyConfiguration(new ActionEntityTypeConfiguration());
            modelBuilder.ApplyConfiguration(new DataEntityTypeConfiguration());
            modelBuilder.ApplyConfiguration(new NodeEntityTypeConfiguration());
            modelBuilder.Entity<TLActivityOperator>().HasBaseType<Activity>();
            modelBuilder.Entity<EmailActivityOperator>().HasBaseType<Activity>();
            modelBuilder.Entity<GenericActivityOperator>().HasBaseType<Activity>();
            modelBuilder.Entity<CampaignActivityOperator>().HasBaseType<Activity>();
            modelBuilder.Entity<ActivityAdapter>().HasBaseType<Activity>();
            modelBuilder.Entity<EmailSender>().HasBaseType<ExtendActivity>();
            modelBuilder.Entity<Email>().HasBaseType<Data>();
            modelBuilder.Entity<Comment>().HasBaseType<Data>();
            modelBuilder.Entity<TLeave>().HasBaseType<Data>();
            modelBuilder.Entity<Contact>().HasBaseType<Data>();
            modelBuilder.Entity<Campaign>().HasBaseType<Data>();
        }
    }
}

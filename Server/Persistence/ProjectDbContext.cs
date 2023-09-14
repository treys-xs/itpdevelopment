using Microsoft.EntityFrameworkCore;
using Server.Application.Interfaces;
using Server.Domain;

namespace Server.Persistence
{
    public class ProjectDbContext : DbContext, IProjectDbContext
    {
        public DbSet<Domain.Project> Projects { get; set; }
        public DbSet<Domain.Task> Tasks { get; set; }
        public DbSet<TaskComment> TaskComments { get; set; }

        public ProjectDbContext(DbContextOptions<ProjectDbContext> options)
            : base(options) 
        {
            Database.EnsureCreated();
        }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken) 
        {
            return base.SaveChangesAsync(cancellationToken);
        }
        

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }
    }
}

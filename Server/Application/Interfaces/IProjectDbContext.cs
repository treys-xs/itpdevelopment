using Microsoft.EntityFrameworkCore;
using Server.Domain;

namespace Server.Application.Interfaces
{
    public interface IProjectDbContext
    {
        DbSet<Domain.Project> Projects { get; set; }
        DbSet<Domain.Task> Tasks { get; set; }
        DbSet<Domain.TaskComment> TaskComments { get; set; }
    }
}

using MediatR;
using Microsoft.EntityFrameworkCore;
using Server.Application.Interfaces;

namespace Server.Application.Task.Commands.CreateTask
{
    public class CreateTaskCommandHandler : IRequestHandler<CreateTaskCommand, Guid>
    {
        private readonly IProjectDbContext _dbContext;

        public CreateTaskCommandHandler(IProjectDbContext dbContext) =>
            _dbContext = dbContext;

        public async Task<Guid> Handle(CreateTaskCommand request, CancellationToken cancellationToken)
        {
            var project = await _dbContext.Projects.FirstOrDefaultAsync(project => project.Id == request.ProjectId);

            if (project == null)
            {
                throw new InvalidOperationException();
            }

            var task = new Domain.Task()
            {
                Id = Guid.NewGuid(),
                Name = request.Name,
                Description = request.Description,
                CreatedDate = DateTime.Now.Date,
                UpdatedDate = DateTime.Now.Date,
                ProjectId = request.ProjectId,
                Project = project,
                AmountTime = (DateTime.Parse(request.EndDate) - DateTime.Parse(request.StartDate)).Hours,
                StartDate = DateTime.Parse(request.StartDate),
                EndDate = DateTime.Parse(request.EndDate)
            };

            await _dbContext.Tasks.AddAsync(task, cancellationToken);
            await _dbContext.SaveChangesAsync(cancellationToken);

            return task.Id;
        }
    }
}

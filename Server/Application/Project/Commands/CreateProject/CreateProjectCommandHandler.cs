using MediatR;
using Microsoft.EntityFrameworkCore;
using Server.Application.Interfaces;
using Server.Domain;

namespace Server.Application.Project.Commands.CreateProject
{
    public class CreateProjectCommandHandler : IRequestHandler<CreateProjectCommand, Guid>
    {
        private readonly IProjectDbContext _dbContext;

        public CreateProjectCommandHandler(IProjectDbContext dbContext) =>
            _dbContext = dbContext;

        public async Task<Guid> Handle(CreateProjectCommand request, CancellationToken cancellationToken)
        {
            var searchProject = await _dbContext.Projects.FirstOrDefaultAsync(project => project.Name == request.Name);

            if (searchProject != null)
            {
                throw new InvalidOperationException();
            }


            var project = new Domain.Project()
            {
                Id = Guid.NewGuid(),
                Name = request.Name,
                CreatedDate = DateTime.Now.Date,
                UpdateDate = DateTime.Now.Date
            };

            await _dbContext.Projects.AddAsync(project, cancellationToken);
            await _dbContext.SaveChangesAsync(cancellationToken);

            return project.Id;
        }


    }
}

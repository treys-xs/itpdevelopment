using MediatR;
using Microsoft.EntityFrameworkCore;
using Server.Application.Interfaces;
using Server.Domain;

namespace Server.Application.Project.Commands.CreateProject
{
    public class CreateProjectCommandHandler : IRequestHandler<CreateProjectCommand, Guid>
    {
        private readonly IRepository _repository;

        public CreateProjectCommandHandler(IRepository repository) =>
            _repository = repository;

        public async Task<Guid> Handle(CreateProjectCommand request, CancellationToken cancellationToken)
        {
            var searchProject = await _repository.FirstOrDefaultAsync<Domain.Project>(project => project.Name == request.Name);

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

            await _repository.CreateAsync<Domain.Project>(project);

            return project.Id;
        }


    }
}

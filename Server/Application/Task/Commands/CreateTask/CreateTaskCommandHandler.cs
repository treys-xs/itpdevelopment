using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Server.Application.Interfaces;

namespace Server.Application.Task.Commands.CreateTask
{
    public class CreateTaskCommandHandler : IRequestHandler<CreateTaskCommand, Guid>
    {
        private readonly IRepository _repository;

        public CreateTaskCommandHandler(IRepository repository) =>
            _repository = repository;


        public async Task<Guid> Handle(CreateTaskCommand request, CancellationToken cancellationToken)
        {
            var project = await _repository.FirstOrDefaultAsync<Domain.Project>(project => project.Id == request.ProjectId);

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

            await _repository.CreateAsync<Domain.Task>(task);

            return task.Id;
        }
    }
}

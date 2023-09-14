using MediatR;

namespace Server.Application.Project.Commands.CreateProject
{
    public class CreateProjectCommand : IRequest<Guid>
    {
        public string Name { get; set; }
    }
}

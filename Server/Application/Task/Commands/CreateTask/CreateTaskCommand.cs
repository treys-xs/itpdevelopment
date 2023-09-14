using MediatR;

namespace Server.Application.Task.Commands.CreateTask
{
    public class CreateTaskCommand : IRequest<Guid>
    {
        public Guid ProjectId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string StartDate { get; set; }
        public string EndDate { get; set; }
    }
}

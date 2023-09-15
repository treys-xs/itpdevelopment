using MediatR;

namespace Server.Application.TaskComment.Commands.CreateTaskComment
{
    public class CreateTaskCommentCommand : IRequest<Guid>
    {
        public Guid TaskId { get; set; }
        public string Type { get; set; }
        public string Content { get; set; }
    }
}

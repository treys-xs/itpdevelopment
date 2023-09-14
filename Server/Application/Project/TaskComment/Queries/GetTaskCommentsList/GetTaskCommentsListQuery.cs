using MediatR;

namespace Server.Application.Project.TaskComment.Queries.GetTaskCommentsList
{
    public class GetTaskCommentsListQuery : IRequest<TaskCommentsListVm>
    {
        public Guid TaskId { get; set; }
    }
}

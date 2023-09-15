using MediatR;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace Server.Application.TaskComment.Queries.GetTaskCommentsList
{
    public class GetTaskCommentsListQuery : IRequest<TaskCommentsListVm>
    {
        public Guid TaskId { get; set; }
        public GetTaskCommentsListQuery(Guid id)
        {
            TaskId = id;
        }

    }
}

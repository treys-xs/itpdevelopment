using MediatR;

namespace Server.Application.Task.Queries.GetTaskDetail
{
    public class GetTaskDetailQuery : IRequest<TaskDetailVm>
    {
        public Guid Id { get; set; }
    }
}

using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Server.Application.Interfaces;


namespace Server.Application.TaskComment.Queries.GetTaskCommentsList
{
    public class GetTaskCommentsListQueryHandler : IRequestHandler<GetTaskCommentsListQuery, TaskCommentsListVm>
    {
        private readonly IMapper _mapper;
        private readonly IRepository _repository;

        public GetTaskCommentsListQueryHandler(IMapper mapper, IRepository repository) =>
            (_mapper, _repository) = (mapper, repository);

        public async Task<TaskCommentsListVm> Handle(GetTaskCommentsListQuery request, CancellationToken cancellationToken)
        {
            var taskComments = await _repository.WhereMap<Domain.TaskComment, TaskCommentsLookupDto>(taskComment => taskComment.TaskId == request.TaskId, _mapper);

            return new TaskCommentsListVm { TaskComments = taskComments };
        }
    }
}

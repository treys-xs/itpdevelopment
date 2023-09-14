using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Server.Application.Interfaces;


namespace Server.Application.Project.TaskComment.Queries.GetTaskCommentsList
{
    public class GetTaskCommentsListQueryHandler : IRequestHandler<GetTaskCommentsListQuery, TaskCommentsListVm>
    {
        private readonly IMapper _mapper;
        private readonly IProjectDbContext _dbContext;

        public GetTaskCommentsListQueryHandler(IMapper mapper, IProjectDbContext dbContext) =>
            (_mapper, _dbContext) = (mapper, dbContext);

        public async Task<TaskCommentsListVm> Handle(GetTaskCommentsListQuery request, CancellationToken cancellationToken)
        {
            var taskComments = await
                _dbContext.TaskComments
                .Where(taskComment => taskComment.TaskId == request.TaskId)
                .ProjectTo<TaskCommentsLookupDto>(_mapper.ConfigurationProvider)
                .ToListAsync(cancellationToken);

            return new TaskCommentsListVm { TaskComments = taskComments };
        }
    }
}

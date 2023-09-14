using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Server.Application.Interfaces;

namespace Server.Application.Task.Queries.GetTaskDetail
{
    public class GetTaskDetailQueryHandler : IRequestHandler<GetTaskDetailQuery, TaskDetailVm>
    {
        private readonly IMapper _mapper;
        private readonly IProjectDbContext _dbContext;

        public GetTaskDetailQueryHandler(IMapper mapper, IProjectDbContext dbContext) =>
            (_mapper, _dbContext) = (mapper, dbContext);

        public async Task<TaskDetailVm> Handle(GetTaskDetailQuery request, CancellationToken cancellationToken)
        {
            var task = await
                _dbContext.Tasks
                .Include(task => task.TaskComments)
                .FirstOrDefaultAsync(task => task.Id == request.Id);

            return _mapper.Map<TaskDetailVm>(task);
        }
    }
}

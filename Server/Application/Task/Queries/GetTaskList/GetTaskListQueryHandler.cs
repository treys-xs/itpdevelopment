using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Server.Application.Interfaces;

namespace Server.Application.Task.Queries.GetTaskList
{
    public class GetTaskListQueryHandler : IRequestHandler<GetTaskListQuery, TaskListVm>
    {
        private readonly IMapper _mapper;
        private readonly IProjectDbContext _dbContext;

        public GetTaskListQueryHandler(IMapper mapper, IProjectDbContext dbContext) =>
            (_mapper, _dbContext) = (mapper, dbContext);

        public async Task<TaskListVm> Handle(GetTaskListQuery request, CancellationToken cancellationToken)
        {
            var tasks = await
                _dbContext.Tasks
                .Include(task => task.Project)
                .Where(task => task.Project.Name == request.ProjectName)
                .ProjectTo<TaskLookupDto>(_mapper.ConfigurationProvider)
                .ToListAsync(cancellationToken);

            return new TaskListVm { Tasks = tasks };
        }
    }
}

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
        private readonly IRepository _repository;

        public GetTaskListQueryHandler(IMapper mapper, IRepository repository) =>
            (_mapper, _repository) = (mapper, repository);


        public async Task<TaskListVm> Handle(GetTaskListQuery request, CancellationToken cancellationToken)
        {
            var tasks = await _repository.IncludeWhereMap<Domain.Task, Domain.Project, TaskLookupDto>(task => task.Project, task => task.Project.Name == request.ProjectName, _mapper);

            return new TaskListVm { Tasks = tasks };
        }
    }
}

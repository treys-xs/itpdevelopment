using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Server.Application.Interfaces;

namespace Server.Application.Task.Queries.GetTaskDetail
{
    public class GetTaskDetailQueryHandler : IRequestHandler<GetTaskDetailQuery, TaskDetailVm>
    {
        private readonly IMapper _mapper;
        private readonly IRepository _repository;

        public GetTaskDetailQueryHandler(IMapper mapper, IRepository repository) =>
            (_mapper, _repository) = (mapper, repository);

        public async Task<TaskDetailVm> Handle(GetTaskDetailQuery request, CancellationToken cancellationToken)
        {
            var task = await
                _repository.IncludeAndFirstOrDefaultAsync<Domain.Task, ICollection<Domain.TaskComment>>(task => task.TaskComments, task => task.Id == request.Id);


            return _mapper.Map<TaskDetailVm>(task);
        }
    }
}

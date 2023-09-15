using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Server.Application.Interfaces;

namespace Server.Application.Project.Queries.GetProjectList
{
    public class GetProjectListQueryHandler : IRequestHandler<GetProjectListQuery, ProjectListVm>
    {
        private readonly IMapper _mapper;
        private readonly IRepository _repository;

        public GetProjectListQueryHandler(IMapper mapper, IRepository repository) =>
            (_mapper, _repository) = (mapper, repository);

        public async Task<ProjectListVm> Handle(GetProjectListQuery request, CancellationToken cancellationToken)
        {
            var projects = await _repository.SelectAllMap<Domain.Project, ProjectLookupDto>(_mapper);

            return new ProjectListVm { Projects = projects };
        }
    }
}

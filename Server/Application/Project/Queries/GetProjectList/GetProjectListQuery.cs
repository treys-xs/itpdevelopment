using MediatR;

namespace Server.Application.Project.Queries.GetProjectList
{
    public class GetProjectListQuery : IRequest<ProjectListVm>
    {
        public GetProjectListQuery(object? data)
        {
        }
    }
}

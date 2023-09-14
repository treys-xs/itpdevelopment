using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Server.Application.Project.Commands.CreateProject;
using Server.Application.Project.Queries.GetProjectList;

namespace Server.Controllers
{
    public class ProjectController : BaseController
    {
        [HttpGet]
        public async Task<ActionResult<ProjectListVm>> GetAll()
        {
            var query = new GetProjectListQuery();
            var vm = await Mediator.Send(query, CancellationToken.None);
            return Ok(vm.Projects);
        }

        [HttpPost]
        public async Task<ActionResult<Guid>> Create([FromBody] CreateProjectCommand command)
        {
            var id = await Mediator.Send(command, CancellationToken.None);
            return Ok(id);
        }
    }
}

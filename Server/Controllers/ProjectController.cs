using Microsoft.AspNetCore.Mvc;
using Server.Application.Project.Commands.CreateProject;
using Server.Application.Project.Queries.GetProjectList;

namespace Server.Controllers
{
    public class ProjectController : BaseController
    {
        [HttpGet]
        public async Task<ActionResult> GetAll()
        {
            var vm = await GetData<GetProjectListQuery, ProjectListVm>(null);
            return Ok(vm.Projects);
        }

        [HttpPost]
        public async Task<ActionResult> Create([FromBody] CreateProjectCommand command)
        {
            var id = await CreateData<CreateProjectCommand, Guid>(command);
            return Ok(id);
        }
    }
}

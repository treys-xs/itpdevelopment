using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Server.Application.Interfaces;
using Server.Application.Project.Commands.CreateProject;
using Server.Application.Project.Queries.GetProjectList;
using Server.Application.Task.Commands.CreateTask;
using Server.Application.Task.Queries.GetTaskDetail;
using Server.Application.Task.Queries.GetTaskList;
using Server.Domain;

namespace Server.Controllers
{
    public class TaskController : BaseController
    {
        [HttpGet("{name}")]
        public async Task<ActionResult<TaskListVm>> GetAll(string name)
        {
            var query = new GetTaskListQuery() 
            {
                ProjectName = name
            };
            var vm = await Mediator.Send(query, CancellationToken.None);
            return Ok(vm.Tasks);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<TaskDetailVm>> Get(Guid id)
        {
            var query = new GetTaskDetailQuery()
            {
                Id = id
            };
            var vm = await Mediator.Send(query, CancellationToken.None);
            return Ok(vm);
        }

        [HttpPost]
        public async Task<ActionResult<Guid>> Create([FromBody] CreateTaskCommand command)
            {
            var id = await Mediator.Send(command, CancellationToken.None);
            return Ok(id);
        }
    }
}

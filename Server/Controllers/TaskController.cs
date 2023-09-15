using Microsoft.AspNetCore.Mvc;
using Server.Application;
using Server.Application.Task.Commands.CreateTask;
using Server.Application.Task.Queries.GetTaskDetail;
using Server.Application.Task.Queries.GetTaskList;

namespace Server.Controllers
{
    public class TaskController : BaseController
    {
        [HttpGet]
        public async Task<ActionResult> GetAll(string name)
        {
            var vm = await GetData<GetTaskListQuery, TaskListVm>(name);
            return Ok(vm.Tasks);
        }

        [HttpGet]
        public async Task<ActionResult> Get(Guid id)
        {
            var vm = await GetData<GetTaskDetailQuery, TaskDetailVm>(id);
            return Ok(vm);
        }

        [HttpPost]
        public async Task<ActionResult> Create([FromBody] CreateTaskCommand command)
        {
            var id = await CreateData<CreateTaskCommand, Guid>(command);
            return Ok(id);
        }
    }
}

using Microsoft.AspNetCore.Mvc;
using Server.Application.TaskComment.Commands.CreateTaskComment;
using Server.Application.TaskComment.Queries.GetTaskCommentsList;

namespace Server.Controllers
{
    public class TaskCommentController : BaseController
    {
        [HttpGet]
        public async Task<ActionResult> Get(Guid id)
        {
            var vm = await GetData<GetTaskCommentsListQuery, TaskCommentsListVm>(id);
            return Ok(vm.TaskComments);
        }

        [HttpPost]
        public async Task<ActionResult> Create([FromBody] CreateTaskCommentCommand command)
        {
            var id = await CreateData<CreateTaskCommentCommand, Guid>(command);
            return Ok(id);
        }

    }
}

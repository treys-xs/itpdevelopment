using Microsoft.AspNetCore.Mvc;
using Server.Application.Project.TaskComment.Commands.CreateTaskComment;
using Server.Application.Project.TaskComment.Queries.GetTaskCommentsList;

namespace Server.Controllers
{
    public class TaskCommentController : BaseController
    {
        [HttpPost]
        public async Task<ActionResult<Guid>> Create([FromBody] CreateTaskCommentCommand command)
        {
            var id = await Mediator.Send(command, CancellationToken.None);
            return Ok(id);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<TaskCommentsListVm>> Get(Guid id)
        {
            var query = new GetTaskCommentsListQuery()
            {
                TaskId = id
            };
            var vm = await Mediator.Send(query, CancellationToken.None);
            return Ok(vm.TaskComments);
        }
    }
}

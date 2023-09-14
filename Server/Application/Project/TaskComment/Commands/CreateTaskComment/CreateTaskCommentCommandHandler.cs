using MediatR;
using Microsoft.EntityFrameworkCore;
using Server.Application.Interfaces;

namespace Server.Application.Project.TaskComment.Commands.CreateTaskComment
{
    public class CreateTaskCommentCommandHandler : IRequestHandler<CreateTaskCommentCommand, Guid>
    {
        private readonly IProjectDbContext _dbContext;

        public CreateTaskCommentCommandHandler(IProjectDbContext dbContext) =>
            _dbContext = dbContext;

        public async Task<Guid> Handle(CreateTaskCommentCommand request, CancellationToken cancellationToken)
        {
            var task = await _dbContext.Tasks.FirstOrDefaultAsync(task => task.Id == request.TaskId);

            if (task == null)
            {
                throw new InvalidOperationException();
            }

            var taskComment = new Domain.TaskComment()
            {
                Id = Guid.NewGuid(),
                Content = request.Content,
                Type = request.Type,
                TaskId = request.TaskId,
                Task = task

            };

            await _dbContext.TaskComments.AddAsync(taskComment, cancellationToken);
            await _dbContext.SaveChangesAsync(cancellationToken);

            return taskComment.Id;
        }
    }
}

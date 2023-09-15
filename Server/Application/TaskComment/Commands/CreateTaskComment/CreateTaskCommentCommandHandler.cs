using MediatR;
using Microsoft.EntityFrameworkCore;
using Server.Application.Interfaces;

namespace Server.Application.TaskComment.Commands.CreateTaskComment
{
    public class CreateTaskCommentCommandHandler : IRequestHandler<CreateTaskCommentCommand, Guid>
    {
        private readonly IRepository _repository;

        public CreateTaskCommentCommandHandler(IRepository repository) =>
            _repository = repository;

        public async Task<Guid> Handle(CreateTaskCommentCommand request, CancellationToken cancellationToken)
        {
            var task = await _repository.FirstOrDefaultAsync<Domain.Task>(task => task.Id == request.TaskId);

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

            await _repository.CreateAsync(taskComment);

            return taskComment.Id;
        }
    }
}

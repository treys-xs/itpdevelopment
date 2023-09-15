using FluentValidation;

namespace Server.Application.TaskComment.Commands.CreateTaskComment
{
    public class CreateTaskCommentCommandValidator : AbstractValidator<CreateTaskCommentCommand>
    {
        public CreateTaskCommentCommandValidator()
        {
            RuleFor(createTaskCommentCommand =>
                    createTaskCommentCommand.TaskId).NotEmpty();
            RuleFor(createTaskCommentCommand =>
                    createTaskCommentCommand.Type).NotEmpty().MaximumLength(20);
            RuleFor(createTaskCommentCommand =>
                    createTaskCommentCommand.Content).NotEmpty().MaximumLength(100);
        }
    }
}

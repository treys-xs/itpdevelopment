using FluentValidation;

namespace Server.Application.Task.Commands.CreateTask
{
    public class CreateTaskCommandValidator : AbstractValidator<CreateTaskCommand>
    {
        public CreateTaskCommandValidator()
        {
            RuleFor(createTaskCommand =>
                createTaskCommand.Name).NotEmpty().MaximumLength(50);
            RuleFor(createTaskCommand =>
                createTaskCommand.Description).NotEmpty().MaximumLength(500);
            RuleFor(createTaskCommand =>
                createTaskCommand.StartDate).NotEmpty().MaximumLength(30);
            RuleFor(createTaskCommand =>
                createTaskCommand.EndDate).NotEmpty().MaximumLength(30);
        }
    }
}

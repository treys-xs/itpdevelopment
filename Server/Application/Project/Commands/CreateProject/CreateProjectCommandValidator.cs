using FluentValidation;

namespace Server.Application.Project.Commands.CreateProject
{
    public class CreateProjectCommandValidator : AbstractValidator<CreateProjectCommand>
    {
        public CreateProjectCommandValidator()
        {
            RuleFor(createProjectCommand =>
                    createProjectCommand.Name).NotEmpty().MaximumLength(50);
        }
    }
}

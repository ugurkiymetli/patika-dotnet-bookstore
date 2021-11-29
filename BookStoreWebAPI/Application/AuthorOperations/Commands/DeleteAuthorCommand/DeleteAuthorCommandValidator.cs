using FluentValidation;
namespace BookStoreWebAPI.Application.AuthorOperations.Commands.CreateAuthorCommand
{
    public class DeleteAuthorCommandValidator : AbstractValidator<DeleteAuthorCommand>
    {
        public DeleteAuthorCommandValidator()
        {
            RuleFor(command => command.AuthorId).GreaterThan(0);
        }
    }
}

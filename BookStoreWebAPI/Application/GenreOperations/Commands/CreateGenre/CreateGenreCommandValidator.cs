using FluentValidation;

namespace BookStoreWebAPI.Application.GenreOperations.Commands.CreateGenre
{
    public class CreateGenreCommandValidator : AbstractValidator<CreateGenreCommand>
    {
        public CreateGenreCommandValidator()
        {
            //name cannot be empty and minimum char is 4
            RuleFor(command => command.Model.Name).NotEmpty().MinimumLength(4);
        }
    }
}
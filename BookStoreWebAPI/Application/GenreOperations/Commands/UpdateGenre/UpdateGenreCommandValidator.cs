using FluentValidation;

namespace BookStoreWebAPI.Application.GenreOperations.Commands.UpdateGenre
{
    public class UpdateGenreCommandValidator : AbstractValidator<UpdateGenreCommand>
    {

        public UpdateGenreCommandValidator()
        {
            //if user inputs name for update, check for min length,
            //if user doesn't input name, don't check for min length
            RuleFor(command => command.Model.Name).MinimumLength(4).When(genre => genre.Model.Name.Trim() != string.Empty);
            //RuleFor(command => command.Model.IsActive).Must(x => x == false || x == true);
        }
    }
}

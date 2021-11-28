using BookStoreWebAPI.Application.GenreOperations.Queries.GetGenresDetail;
using FluentValidation;
namespace BookStoreWebAPI.Application.GenreOperations.Queries.GetGenreDetail
{
    public class CreateGenreCommandValidator : AbstractValidator<GetGenreDetailQuery>
    {
        public CreateGenreCommandValidator()
        {
            RuleFor(query => query.GenreId).GreaterThan(0);
        }
    }
}

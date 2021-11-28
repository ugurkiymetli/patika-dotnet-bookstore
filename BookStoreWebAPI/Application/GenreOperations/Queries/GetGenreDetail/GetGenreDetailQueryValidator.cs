using BookStoreWebAPI.Application.GenreOperations.Queries.GetGenresDetail;
using FluentValidation;
namespace BookStoreWebAPI.Application.GenreOperations.Queries.GetGenreDetail
{
    public class GetGenreDetailQueryValidator : AbstractValidator<GetGenreDetailQuery>
    {
        public GetGenreDetailQueryValidator()
        {
            RuleFor(query => query.GenreId).GreaterThan(0);
        }
    }
}

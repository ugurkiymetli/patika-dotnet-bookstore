using FluentValidation;
namespace BookStoreWebAPI.Application.AuthorOperations.Queries.GetAuthorDetailQuery
{
    public class GetAuthorDetailQueryValidator : AbstractValidator<GetAuthorDetailQuery>
    {
        public GetAuthorDetailQueryValidator()
        {
            RuleFor(query => query.AuthorId).GreaterThan(0);
        }
    }
}

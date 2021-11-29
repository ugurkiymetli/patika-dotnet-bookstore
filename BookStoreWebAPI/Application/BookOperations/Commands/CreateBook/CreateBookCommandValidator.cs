using FluentValidation;
using System;

namespace BookStoreWebAPI.BookOperations.CreateBook
{
    public class CreateBookCommandValidator : AbstractValidator<CreateBookCommand>
    {
        public CreateBookCommandValidator()
        {
            RuleFor(command => command.Model.Title).NotEmpty().MinimumLength(2);
            RuleFor(command => command.Model.GenreId).NotEmpty().GreaterThan(0);
            RuleFor(command => command.Model.AuthorId).NotEmpty().GreaterThan(0);
            RuleFor(command => command.Model.PageCount).NotEmpty().GreaterThan(0);
            RuleFor(command => command.Model.PublishDate.Date).NotEmpty().LessThan(DateTime.Now.Date);
        }
    }
}

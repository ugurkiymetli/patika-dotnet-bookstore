using FluentValidation;
using System;
namespace BookStoreWebAPI.Application.AuthorOperations.Commands.CreateAuthorCommand
{
    public class UpdateAuthorCommandValidator : AbstractValidator<UpdateAuthorCommand>
    {
        public UpdateAuthorCommandValidator()
        {
            //RuleFor(command => command.Model.Name).NotEmpty().MinimumLength(3);
            //RuleFor(command => command.Model.Surname).NotEmpty().MinimumLength(3);

            RuleFor(command => command.Model.Name).MinimumLength(3).When(author => author.Model.Name.Trim() != string.Empty); ;
            RuleFor(command => command.Model.Surname).MinimumLength(3).When(author => author.Model.Surname.Trim() != string.Empty);
            RuleFor(command => command.Model.BirthDate.Date).NotEmpty().LessThan(DateTime.Now.Date);
        }
    }
}

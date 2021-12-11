using BookStoreWebAPI.DbOperations;
using System;
using System.Linq;
namespace BookStoreWebAPI.Application.AuthorOperations.Commands.CreateAuthorCommand
{
    public class UpdateAuthorCommand
    {

        public UpdateAuthorCommandModel Model { get; set; }
        private readonly IBookStoreDBContext _context;
        public int AuthorId { get; set; }

        public UpdateAuthorCommand( IBookStoreDBContext context )
        {
            _context = context;
        }
        public void Handle()
        {
            var author = _context.Authors.SingleOrDefault(author => author.Id == AuthorId);
            if ( author == null )
                throw new InvalidOperationException("This author is not found!!");
            //author.Name = Model.Name != default ? Model.Name : author.Name;
            //author.Surname = Model.Surname != default ? Model.Surname : author.Surname;

            author.Name = String.IsNullOrEmpty(Model.Name.Trim()) ? author.Name : Model.Name;
            author.Surname = String.IsNullOrEmpty(Model.Surname.Trim()) ? author.Surname : Model.Surname;
            author.BirthDate = Model.BirthDate != default ? Model.BirthDate : author.BirthDate;
            _context.SaveChanges();
        }
    }
}

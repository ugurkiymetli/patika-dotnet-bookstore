using HelloWebAPI.Controllers;
using HelloWebAPI.DbOperations;
using System;
using System.Linq;
namespace HelloWebAPI.BookOperations.CreateBook
{
    public class CreateBookCommand
    {
        public CreateBookModel Model { get; set; }
        private readonly BookStoreDBContext _dbContext;

        public CreateBookCommand( BookStoreDBContext dbContext )
        {
            _dbContext = dbContext;
        }
        public void Handle()
        {
            var book = _dbContext.Books.SingleOrDefault(book => book.Title == Model.Title);
            if ( book is not null )
                throw new InvalidOperationException("This book already exists!!");
            book = new Book
            {
                Title = Model.Title,
                GenreId = Model.GenreId,
                PageCount = Model.PageCount,
                PublishDate = Model.PublishDate
            };
            _dbContext.Books.Add(book);
            _dbContext.SaveChanges();
        }

    }
}

using BookStoreWebAPI.DbOperations;
using System;
using System.Linq;

namespace BookStoreWebAPI.BookOperations.UpdateBook
{
    public class UpdateBookCommand
    {
        public UpdateBookCommandModel Model { get; set; }
        public int BookId { get; set; }
        private readonly BookStoreDBContext _dbContext;

        public UpdateBookCommand( BookStoreDBContext dbContext )
        {
            _dbContext = dbContext;
        }
        public void Handle()
        {
            var book = _dbContext.Books.SingleOrDefault(book => book.Id == BookId);
            if ( book is null )
                throw new InvalidOperationException("This Book is not found!!");
            book.Title = Model.Title != default ? Model.Title : book.Title;
            book.GenreId = Model.GenreId != default ? Model.GenreId : book.GenreId;
            //book.PageCount = Model.PageCount != default ? Model.PageCount : book.PageCount,
            //book.PublishDate = Model.PublishDate != default ? Model.PublishDate : book.PublishDate,
            _dbContext.SaveChanges();
        }
    }
}

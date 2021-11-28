using BookStoreWebAPI.DbOperations;
using System;
using System.Linq;

namespace BookStoreWebAPI.BookOperations.DeleteBook
{
    public class DeleteBookCommand
    {
        private readonly BookStoreDBContext _dbContext;
        public int BookId { get; set; }
        public DeleteBookCommand( BookStoreDBContext dBContext )
        {
            _dbContext = dBContext;
        }
        public void Handle()
        {
            var book = _dbContext.Books.SingleOrDefault(book => book.Id == BookId);
            if ( book is null )
                throw new InvalidOperationException("This book is not found!!");
            _dbContext.Books.Remove(book);
            _dbContext.SaveChanges();
        }
    }
}

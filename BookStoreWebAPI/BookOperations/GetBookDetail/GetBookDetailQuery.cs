using BookStoreWebAPI.Common;
using BookStoreWebAPI.DbOperations;
using System;
using System.Linq;

namespace BookStoreWebAPI.BookOperations.GetBookDetail
{
    public class GetBookDetailQuery
    {
        private readonly BookStoreDBContext _dbContext;
        public int BookId { get; set; }
        public GetBookDetailQuery( BookStoreDBContext dBContext )
        {
            _dbContext = dBContext;
        }
        public GetBookDetailModel Handle()
        {
            var book = _dbContext.Books.Where(book => book.Id == BookId).SingleOrDefault();
            if ( book is null )
                throw new InvalidOperationException("This book is not found!!");

            GetBookDetailModel bookDetailModel = new()
            {
                Title = book.Title,
                Genre = ( ( GenreEnum )book.GenreId ).ToString(),
                PublishDate = book.PublishDate.Date.ToString("dd/MM/yyyy"),
                PageCount = book.PageCount
            };

            return bookDetailModel;


        }
    }

}

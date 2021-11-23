using BookStoreWebAPI.Common;
using BookStoreWebAPI.Controllers;
using BookStoreWebAPI.DbOperations;
using System.Collections.Generic;
using System.Linq;

namespace BookStoreWebAPI.BookOperations.GetBooks
{
    public class GetBooksQuery
    {
        private readonly BookStoreDBContext _dbContext;
        public GetBooksQuery( BookStoreDBContext dBContext )
        {
            _dbContext = dBContext;
        }
        public List<GetBookViewModel> Handle()
        {
            var bookList = _dbContext.Books.OrderBy(book => book.Id).ToList<Book>();
            List<GetBookViewModel> bookViewModel = new List<GetBookViewModel>();
            foreach ( var book in bookList )
            {
                bookViewModel.Add(new GetBookViewModel()
                {
                    Title = book.Title,
                    Genre = ( ( GenreEnum )book.GenreId ).ToString(),
                    PublishDate = book.PublishDate.Date.ToString("dd/MM/yyyy"),
                    PageCount = book.PageCount
                });
            }
            return bookViewModel;
        }
    }

}

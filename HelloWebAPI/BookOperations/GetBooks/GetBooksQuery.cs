using HelloWebAPI.Common;
using HelloWebAPI.Controllers;
using HelloWebAPI.DbOperations;
using System.Collections.Generic;
using System.Linq;

namespace HelloWebAPI.BookOperations.GetBooks
{
    public class GetBooksQuery
    {
        private readonly BookStoreDBContext _dbContext;
        public GetBooksQuery( BookStoreDBContext dBContext )
        {
            _dbContext = dBContext;
        }
        public List<BookViewModel> Handle()
        {
            var bookList = _dbContext.Books.OrderBy(book => book.Id).ToList<Book>();
            List<BookViewModel> bookViewModel = new List<BookViewModel>();
            foreach ( var book in bookList )
            {
                bookViewModel.Add(new BookViewModel()
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
    public class BookViewModel
    {
        public string Title { get; set; }
        public int PageCount { get; set; }
        public string PublishDate { get; set; }
        public string Genre { get; set; }
    }
}

using AutoMapper;
using BookStoreWebAPI.DbOperations;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
namespace BookStoreWebAPI.BookOperations.GetBooks
{
    public class GetBooksQuery
    {
        private readonly BookStoreDBContext _context;
        private readonly IMapper _mapper;
        public GetBooksQuery( BookStoreDBContext context, IMapper mapper )
        {
            _context = context;
            _mapper = mapper;
        }
        public List<GetBooksQueryModel> Handle()
        {
            var bookList = _context.Books.Include(book => book.Genre).Include(book => book.Author).OrderBy(book => book.Id)/*.ToList<Book>()*/;
            List<GetBooksQueryModel> bookViewModel = _mapper.Map<List<GetBooksQueryModel>>(bookList);
            return bookViewModel;
        }
    }

}

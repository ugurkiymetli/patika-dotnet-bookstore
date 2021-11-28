using AutoMapper;
using BookStoreWebAPI.Controllers;
using BookStoreWebAPI.DbOperations;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
namespace BookStoreWebAPI.BookOperations.GetBooks
{
    public class GetBooksQuery
    {
        private readonly BookStoreDBContext _dbContext;
        private readonly IMapper _mapper;
        public GetBooksQuery( BookStoreDBContext dBContext, IMapper mapper )
        {
            _dbContext = dBContext;
            _mapper = mapper;
        }
        public List<GetBookModel> Handle()
        {
            var bookList = _dbContext.Books.Include(book => book.Genre).OrderBy(book => book.Id).ToList<Book>();
            List<GetBookModel> bookViewModel = _mapper.Map<List<GetBookModel>>(bookList);
            return bookViewModel;
        }
    }

}

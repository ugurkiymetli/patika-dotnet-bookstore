using AutoMapper;
using BookStoreWebAPI.Controllers;
using BookStoreWebAPI.DbOperations;
using System;
using System.Linq;
namespace BookStoreWebAPI.BookOperations.CreateBook
{
    public class CreateBookCommand
    {
        public CreateBookModel Model { get; set; }
        private readonly BookStoreDBContext _dbContext;
        private readonly IMapper _mapper;

        public CreateBookCommand( BookStoreDBContext dbContext, IMapper mapper )
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }
        public void Handle()
        {
            var book = _dbContext.Books.SingleOrDefault(book => book.Title == Model.Title);
            if ( book is not null )
                throw new InvalidOperationException("This book already exists!!");
            book = _mapper.Map<Book>(Model);
            _dbContext.Books.Add(book);
            _dbContext.SaveChanges();
        }
    }
}

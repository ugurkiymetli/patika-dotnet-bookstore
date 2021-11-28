using AutoMapper;
using BookStoreWebAPI.Controllers;
using BookStoreWebAPI.DbOperations;
using System;
using System.Linq;
namespace BookStoreWebAPI.BookOperations.CreateBook
{
    public class CreateGenreCommand
    {
        public CreateBookModel Model { get; set; }
        private readonly BookStoreDBContext _context;
        private readonly IMapper _mapper;

        public CreateGenreCommand( BookStoreDBContext context, IMapper mapper )
        {
            _context = context;
            _mapper = mapper;
        }
        public void Handle()
        {
            var book = _context.Books.SingleOrDefault(book => book.Title == Model.Title);
            if ( book is not null )
                throw new InvalidOperationException("This book already exists!!");
            book = _mapper.Map<Book>(Model);
            _context.Books.Add(book);
            _context.SaveChanges();
        }
    }
}

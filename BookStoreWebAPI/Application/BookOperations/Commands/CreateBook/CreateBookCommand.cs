using AutoMapper;
using BookStoreWebAPI.DbOperations;
using BookStoreWebAPI.Entities;
using System;
using System.Linq;
namespace BookStoreWebAPI.BookOperations.CreateBook
{
    public class CreateBookCommand
    {
        public CreateBookCommandModel Model { get; set; }
        private readonly IBookStoreDBContext _context;
        private readonly IMapper _mapper;

        public CreateBookCommand( IBookStoreDBContext context, IMapper mapper )
        {
            _context = context;
            _mapper = mapper;
        }
        public void Handle()
        {
            var book = _context.Books.SingleOrDefault(book => book.Title == Model.Title);
            if ( book is not null )
                throw new InvalidOperationException("This book already exists!!");

            var genre = _context.Genres.SingleOrDefault(genre => genre.Id == Model.GenreId);
            if ( genre == null )
                throw new InvalidOperationException("Genre not found!");
            var author = _context.Authors.SingleOrDefault(author => author.Id == Model.AuthorId);
            if ( author == null )
                throw new InvalidOperationException("Author not found!");

            book = _mapper.Map<Book>(Model);
            _context.Books.Add(book);
            _context.SaveChanges();
        }
    }
}

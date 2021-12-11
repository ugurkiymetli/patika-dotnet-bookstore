using BookStoreWebAPI.DbOperations;
using System;
using System.Linq;

namespace BookStoreWebAPI.BookOperations.UpdateBook
{
    public class UpdateBookCommand
    {
        public UpdateBookCommandModel Model { get; set; }
        public int BookId { get; set; }

        private readonly IBookStoreDBContext _context;

        public UpdateBookCommand( IBookStoreDBContext context )
        {
            _context = context;
        }
        public void Handle()
        {
            var book = _context.Books.SingleOrDefault(book => book.Id == BookId);
            if ( book is null )
                throw new InvalidOperationException("This book is not found!!");

            //check genre and author is valid
            var genre = _context.Genres.SingleOrDefault(genre => genre.Id == Model.GenreId);
            if ( genre == null )
                throw new InvalidOperationException("This genre not found!");
            var author = _context.Authors.SingleOrDefault(author => author.Id == Model.AuthorId);
            if ( author == null )
                throw new InvalidOperationException("This author not found!");

            //check if title is empty => if empty keep original title, if not save new title            
            book.Title = String.IsNullOrEmpty(Model.Title.Trim()) ? book.Title : Model.Title;
            book.GenreId = Model.GenreId != default ? Model.GenreId : book.GenreId;
            book.AuthorId = Model.AuthorId != default ? Model.AuthorId : book.AuthorId;
            //book.PageCount = Model.PageCount != default ? Model.PageCount : book.PageCount,
            //book.PublishDate = Model.PublishDate != default ? Model.PublishDate : book.PublishDate,
            _context.SaveChanges();
        }
    }
}

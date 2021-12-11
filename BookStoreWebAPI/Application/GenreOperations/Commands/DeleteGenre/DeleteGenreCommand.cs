using BookStoreWebAPI.DbOperations;
using System;
using System.Linq;
namespace BookStoreWebAPI.Application.GenreOperations.Commands.DeleteGenre
{
    public class DeleteGenreCommand

    {
        private readonly IBookStoreDBContext _context;
        public int GenreId { get; set; }
        public DeleteGenreCommand( IBookStoreDBContext context )
        {
            _context = context;
        }

        public void Handle()
        {
            var genre = _context.Genres.SingleOrDefault(genre => genre.Id == GenreId);
            if ( genre == null )
                throw new InvalidOperationException("This genre is not found!!");
            _context.Genres.Remove(genre);
            _context.SaveChanges();
        }

    }
}

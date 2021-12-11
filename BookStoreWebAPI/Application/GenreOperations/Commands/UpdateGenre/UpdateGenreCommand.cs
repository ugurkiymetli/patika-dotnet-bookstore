using BookStoreWebAPI.DbOperations;
using System;
using System.Linq;
namespace BookStoreWebAPI.Application.GenreOperations.Commands.UpdateGenre
{
    public class UpdateGenreCommand
    {
        public UpdateGenreCommandModel Model { get; set; }
        private readonly IBookStoreDBContext _context;
        public int GenreId { get; set; }

        public UpdateGenreCommand( IBookStoreDBContext context )
        {
            _context = context;
        }
        public void Handle()
        {
            var genre = _context.Genres.SingleOrDefault(genre => genre.Id == GenreId);
            if ( genre is null )
                throw new InvalidOperationException("This genre is not found!!");
            if ( _context.Genres.Any(book => book.Name.ToLower() == Model.Name.ToLower() && book.Id != GenreId) )
                throw new InvalidOperationException("This genre is already  exists!!");
            //genre.Name = Model.Name.Trim() == default ? genre.Name : Model.Name;
            genre.Name = String.IsNullOrEmpty(Model.Name.Trim()) ? genre.Name : Model.Name;
            genre.IsActive = Model.IsActive;
            _context.SaveChanges();
        }
    }
}

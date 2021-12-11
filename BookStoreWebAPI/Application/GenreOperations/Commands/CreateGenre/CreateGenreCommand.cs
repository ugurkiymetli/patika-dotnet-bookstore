using BookStoreWebAPI.DbOperations;
using BookStoreWebAPI.Entities;
using System;
using System.Linq;

namespace BookStoreWebAPI.Application.GenreOperations.Commands.CreateGenre
{
    public class CreateGenreCommand
    {
        public CreateGenreModel Model { get; set; }
        private readonly IBookStoreDBContext _context;

        public CreateGenreCommand( IBookStoreDBContext context )
        {
            _context = context;
        }

        public void Handle()
        {
            var genre = _context.Genres.SingleOrDefault(genre => genre.Name == Model.Name);
            if ( genre is not null )
                throw new InvalidOperationException("This genre already exists!!");
            genre = new Genre
            {
                Name = Model.Name
            };
            _context.Genres.Add(genre);
            _context.SaveChanges();
        }

    }
}

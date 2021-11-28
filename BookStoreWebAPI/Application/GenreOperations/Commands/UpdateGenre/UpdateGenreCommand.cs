using AutoMapper;
using BookStoreWebAPI.DbOperations;
using System;
using System.Linq;
namespace BookStoreWebAPI.Application.GenreOperations.Commands.UpdateGenre
{
    public class UpdateGenreCommand
    {
        public UpdateGenreCommandModel Model { get; set; }
        private readonly IMapper _mapper;
        private readonly BookStoreDBContext _context;
        public int GenreId { get; set; }

        public UpdateGenreCommand( BookStoreDBContext context, IMapper mapper )
        {
            _context = context;
            _mapper = mapper;
        }
        public void Handle()
        {
            var genre = _context.Genres.SingleOrDefault(genre => genre.Id == GenreId);
            if ( genre is null )
                throw new InvalidOperationException("This genre is not found!!");
            if ( _context.Genres.Any(book => book.Name.ToLower() == Model.Name.ToLower() && book.Id != GenreId) )
                throw new InvalidOperationException("This genre is not found!!");
        }
    }
}

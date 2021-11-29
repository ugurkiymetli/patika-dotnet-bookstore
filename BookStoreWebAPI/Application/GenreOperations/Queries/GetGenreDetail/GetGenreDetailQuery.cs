using AutoMapper;
using BookStoreWebAPI.Application.GenreOperations.Queries.GetGenres;
using BookStoreWebAPI.DbOperations;
using System;
using System.Linq;
namespace BookStoreWebAPI.Application.GenreOperations.Queries.GetGenresDetail
{
    public class GetGenreDetailQuery
    {
        public int GenreId { get; set; }
        private readonly IMapper _mapper;
        private readonly BookStoreDBContext _context;

        public GetGenreDetailQuery( BookStoreDBContext context, IMapper mapper )
        {
            _context = context;
            _mapper = mapper;
        }

        public GetGenreDetailModel Handle()
        {
            var genre = _context.Genres.SingleOrDefault(genre => genre.IsActive && genre.Id == GenreId);

            if ( genre == null )
                throw new InvalidOperationException("Genre not found!");
            GetGenreDetailModel returnObj = _mapper.Map<GetGenreDetailModel>(genre);
            return returnObj;
        }
    }
}

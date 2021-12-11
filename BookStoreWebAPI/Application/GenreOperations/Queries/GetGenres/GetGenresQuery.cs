using AutoMapper;
using BookStoreWebAPI.DbOperations;
using System.Collections.Generic;
using System.Linq;

namespace BookStoreWebAPI.Application.GenreOperations.Queries.GetGenres
{
    public class GetGenresQuery
    {
        public readonly IBookStoreDBContext _context;
        public readonly IMapper _mapper;
        public GetGenresQuery( IBookStoreDBContext context, IMapper mapper )
        {
            _context = context;
            _mapper = mapper;
        }
        public List<GetGenreModel> Handle()
        {
            var genres = _context.Genres.Where(genre => genre.IsActive).OrderBy(genre => genre.Id);
            List<GetGenreModel> returnObj = _mapper.Map<List<GetGenreModel>>(genres);
            return returnObj;
        }
    }

}

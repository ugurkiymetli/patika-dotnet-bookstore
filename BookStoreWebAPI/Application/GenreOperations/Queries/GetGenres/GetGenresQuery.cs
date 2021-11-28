using AutoMapper;
using BookStoreWebAPI.DbOperations;
using System.Collections.Generic;
using System.Linq;

namespace BookStoreWebAPI.Application.GenreOperations.Queries.GetGenres
{
    public class GetGenresQuery
    {
        public readonly BookStoreDBContext _context;
        public readonly IMapper _mapper;
        public GetGenresQuery( BookStoreDBContext context, IMapper mapper )
        {
            _context = context;
            _mapper = mapper;
        }
        public List<GetGenreModel> Handle()
        {
            var genres = _context.Genres.Where(book => book.IsActive).OrderBy(book => book.Id);
            List<GetGenreModel> returnObj = _mapper.Map<List<GetGenreModel>>(genres);
            return returnObj;
        }
    }

}

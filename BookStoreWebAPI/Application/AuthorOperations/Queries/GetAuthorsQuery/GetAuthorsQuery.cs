using AutoMapper;
using BookStoreWebAPI.DbOperations;
using BookStoreWebAPI.Entities;
using System.Collections.Generic;
using System.Linq;

namespace BookStoreWebAPI.Application.AuthorOperations.Queries.GetAuthorsQuery
{
    public class GetAuthorsQuery
    {
        private readonly IBookStoreDBContext _context;
        private readonly IMapper _mapper;

        public GetAuthorsQuery( IBookStoreDBContext context, IMapper mapper )
        {
            _context = context;
            _mapper = mapper;
        }
        public List<GetAuthorsQueryModel> Handle()
        {
            var authorList = _context.Authors.OrderBy(author => author.Id).ToList<Author>();
            List<GetAuthorsQueryModel> returnObj = _mapper.Map<List<GetAuthorsQueryModel>>(authorList);
            return returnObj;
        }

    }
}

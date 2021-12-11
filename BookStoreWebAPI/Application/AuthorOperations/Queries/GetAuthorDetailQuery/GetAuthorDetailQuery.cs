using AutoMapper;
using BookStoreWebAPI.DbOperations;
using System;
using System.Linq;
namespace BookStoreWebAPI.Application.AuthorOperations.Queries.GetAuthorDetailQuery
{
    public class GetAuthorDetailQuery
    {
        public int AuthorId { get; set; }
        private readonly IBookStoreDBContext _context;
        private readonly IMapper _mapper;

        public GetAuthorDetailQuery( IBookStoreDBContext context, IMapper mapper )
        {
            _context = context;
            _mapper = mapper;
        }

        public GetAuthorDetailQueryModel Handle()
        {
            var author = _context.Authors.SingleOrDefault(author => author.Id == AuthorId);
            if ( author == null )
                throw new InvalidOperationException("Author not found!");

            GetAuthorDetailQueryModel returnObj = _mapper.Map<GetAuthorDetailQueryModel>(author);
            return returnObj;
        }
    }
}

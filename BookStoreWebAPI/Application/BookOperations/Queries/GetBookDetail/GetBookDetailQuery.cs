using AutoMapper;
using BookStoreWebAPI.DbOperations;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;

namespace BookStoreWebAPI.BookOperations.GetBookDetail
{
    public class GetBookDetailQuery
    {
        private readonly BookStoreDBContext _dbContext;
        private readonly IMapper _mapper;
        public int BookId { get; set; }
        public GetBookDetailQuery( BookStoreDBContext dBContext, IMapper mapper )
        {
            _dbContext = dBContext;
            _mapper = mapper;
        }
        public GetBookDetailQueryModel Handle()
        {
            var book = _dbContext.Books.Include(book => book.Genre).Include(book => book.Author).Where(book => book.Id == BookId).SingleOrDefault();
            if ( book is null )
                throw new InvalidOperationException("This book is not found!!");
            GetBookDetailQueryModel bookDetailModel = _mapper.Map<GetBookDetailQueryModel>(book);
            return bookDetailModel;
        }
    }

}

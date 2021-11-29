using AutoMapper;
using BookStoreWebAPI.DbOperations;
using System;
using System.Linq;

namespace BookStoreWebAPI.Application.AuthorOperations.Commands.CreateAuthorCommand
{
    public class DeleteAuthorCommand
    {
        public int AuthorId { get; set; }


        private readonly IMapper _mapper;
        private readonly BookStoreDBContext _context;

        public DeleteAuthorCommand( BookStoreDBContext context, IMapper mapper )
        {
            _context = context;
            _mapper = mapper;
        }

        public void Handle()
        {
            var author = _context.Authors.SingleOrDefault(author => author.Id == AuthorId);
            if ( author == null )
                throw new InvalidOperationException("This author is not found!!");

            bool authorHasBooks = _context.Books.Any(book => book.Id == AuthorId);
            if ( authorHasBooks )
                throw new InvalidOperationException("This author has books and cannot be deleted. Delete books first!!");

            _context.Authors.Remove(author);
            _context.SaveChanges();
        }
    }
}

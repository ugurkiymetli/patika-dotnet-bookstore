using AutoMapper;
using BookStoreWebAPI.DbOperations;
using BookStoreWebAPI.Entities;
using System;
using System.Linq;

namespace BookStoreWebAPI.Application.AuthorOperations.Commands.CreateAuthorCommand
{
    public class CreateAuthorCommand
    {
        public CreateAuthorCommandModel Model { get; set; }
        private readonly IMapper _mapper;
        private readonly BookStoreDBContext _context;

        public CreateAuthorCommand( BookStoreDBContext context, IMapper mapper )
        {
            _context = context;
            _mapper = mapper;
        }

        public void Handle()
        {
            var author = _context.Authors.SingleOrDefault(author => author.Name == Model.Name);

            if ( author is not null )
                throw new InvalidOperationException("This author already exists!!");
            author = _mapper.Map<Author>(Model);
            _context.Authors.Add(author);
            _context.SaveChanges();
        }
    }
}

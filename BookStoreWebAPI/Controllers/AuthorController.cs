using AutoMapper;
using BookStoreWebAPI.Application.AuthorOperations.Commands.CreateAuthorCommand;
using BookStoreWebAPI.Application.AuthorOperations.Queries.GetAuthorDetailQuery;
using BookStoreWebAPI.Application.AuthorOperations.Queries.GetAuthorsQuery;
using BookStoreWebAPI.DbOperations;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;

namespace BookStoreWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorController : ControllerBase
    {
        private readonly BookStoreDBContext _context;
        private readonly IMapper _mapper;

        public AuthorController( IMapper mapper, BookStoreDBContext context )
        {
            _mapper = mapper;
            _context = context;
        }

        //GetAuthors
        [HttpGet]
        public IActionResult GetAuthors()
        {
            GetAuthorsQuery query = new(_context, _mapper);
            var result = query.Handle();
            return Ok(result);
        }

        //GetAuthorDetailById
        [HttpGet("{id}")]
        public IActionResult GetAuthorDetail( int id )
        {
            GetAuthorDetailQuery query = new(_context, _mapper);
            query.AuthorId = id;

            GetAuthorDetailQueryValidator validator = new();
            validator.ValidateAndThrow(query);

            var result = query.Handle();
            return Ok(result);
        }

        //AddAuthor
        [HttpPost]
        public IActionResult AddAuthor( [FromBody] CreateAuthorCommandModel newAuthor )
        {
            CreateAuthorCommand command = new(_context, _mapper);
            command.Model = newAuthor;
            CreateAuthorCommandValidator validator = new();
            validator.ValidateAndThrow(command);
            command.Handle();
            return Ok();
        }

        //UpdateAuthor
        [HttpPut("{id}")]
        public IActionResult UpdateAuthor( int id, [FromBody] UpdateAuthorCommandModel updatedAuthor )
        {
            UpdateAuthorCommand command = new(_context);
            command.Model = updatedAuthor;
            command.AuthorId = id;
            UpdateAuthorCommandValidator validator = new();
            validator.ValidateAndThrow(command);
            command.Handle();
            return Ok();
        }

        //DeleteAuthor 
        //Deletes Author but has to check if author has any active books.
        [HttpDelete("{id}")]
        public IActionResult DeleteAuthor( int id )
        {
            DeleteAuthorCommand command = new(_context, _mapper);
            command.AuthorId = id;
            DeleteAuthorCommandValidator validator = new();
            validator.ValidateAndThrow(command);
            command.Handle();
            return Ok();
        }
    }
}

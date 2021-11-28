using AutoMapper;
using BookStoreWebAPI.Application.GenreOperations.Commands.CreateGenre;
using BookStoreWebAPI.Application.GenreOperations.Commands.DeleteGenre;
using BookStoreWebAPI.Application.GenreOperations.Commands.UpdateGenre;
using BookStoreWebAPI.Application.GenreOperations.Queries.GetGenreDetail;
using BookStoreWebAPI.Application.GenreOperations.Queries.GetGenres;
using BookStoreWebAPI.Application.GenreOperations.Queries.GetGenresDetail;
using BookStoreWebAPI.DbOperations;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;

namespace BookStoreWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class GenreController : ControllerBase
    {
        private readonly BookStoreDBContext _context;
        private readonly IMapper _mapper;

        public GenreController( IMapper mapper, BookStoreDBContext context )
        {
            _mapper = mapper;
            _context = context;
        }
        //GetGenres
        [HttpGet]
        public IActionResult GetGenres()
        {
            GetGenresQuery query = new(_context, _mapper);
            var result = query.Handle();
            return Ok(result);
        }

        //GetGenreDetailByID
        [HttpGet("{id}")]
        public IActionResult GetGenreDetail( int id )
        {
            GetGenreDetailQuery query = new(_context, _mapper);
            query.GenreId = id;

            GetGenreDetailQueryValidator validator = new();
            validator.ValidateAndThrow(query);

            var result = query.Handle();
            return Ok(result);
        }

        //CreateGenre
        [HttpPost]
        public IActionResult AddGenre( [FromBody] CreateGenreModel newGenre )
        {
            CreateGenreCommand command = new(_context);
            command.Model = newGenre;
            CreateGenreCommandValidator validator = new();
            validator.ValidateAndThrow(command);
            command.Handle();
            return Ok();
        }

        //UpdateGenre
        [HttpPut("{id}")]
        public IActionResult UpdateGenre( int id, [FromBody] UpdateGenreCommandModel updateGenre )
        {
            UpdateGenreCommand command = new(_context);
            command.GenreId = id;
            command.Model = updateGenre;

            UpdateGenreCommandValidator validator = new();
            validator.ValidateAndThrow(command);

            command.Handle();
            return Ok();
        }
        [HttpDelete("{id}")]
        public IActionResult DeleteGenre( int id )
        {
            DeleteGenreCommand command = new(_context);
            command.GenreId = id;

            DeleteGenreCommandValidator validator = new();
            validator.ValidateAndThrow(command);

            command.Handle();
            return Ok();
        }
    }
}
